using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IESTM25RayFiles;

namespace IESTM25FileViewer
{
    public partial class FormRayFileViewer : Form
    {
        private string _CurrentDataGridViewName;
        private int _DataGridViewisAddedCount=0;

        public FormRayFileViewer()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (openIESTM25FileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    ulong numrays = 10;
                    var rayFile  = new IESTM25File(openIESTM25FileDialog.FileName, numrays);
                    SetHeaderTab(rayFile.FileHeader);
                    SetFlagTab(rayFile.DataFlags);
                    SetDescriptionTab(rayFile.DescriptionHeader);
                    SetSpectralTablesTab(rayFile.SpectralTables);
                    SetSampleRayDataTab(rayFile.RayData, numrays);
                    textFileName.Text = openIESTM25FileDialog.FileName;
                }
                catch (InvalidTM25Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message + " " + ex.FieldName + " " + ex.FieldValue);
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void SetSampleRayDataTab(RayDataLinesBlock rayData, ulong numrays )
        {
            tabRayData.Controls.Clear();
            DataGridView dg = new DataGridView();
            dg.Size = new Size(1000, 300);
            foreach (var columname in rayData.RayDataMembers)
            {
                dg.Columns.Add(columname.Replace(' ','_').ToLower(), columname);
            }


            for (ulong i = 0; i < numrays; i++)
            {
                int rowId = dg.Rows.Add();
                DataGridViewRow row = dg.Rows[rowId];
                for (int j = 0; j < rayData.RayDataMembers.Length; j++)
                {
                    row.Cells[j].Value = rayData.Rays[i][j];
                }
            }


            dg.Dock = DockStyle.Top;

            dg.BackgroundColor = Color.LightGray;
            dg.BorderStyle = BorderStyle.Fixed3D;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToOrderColumns = true;
            dg.ReadOnly = true;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.MultiSelect = false;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dg.AllowUserToResizeColumns = false;
            dg.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dg.AllowUserToResizeRows = false;
            dg.RowHeadersVisible = false;
            dg.BorderStyle = BorderStyle.None;

            tabRayData.Controls.Add(dg);
        }

        private void SetSpectralTablesTab(SpectralTableBlock spectralTables)
        {
            for (int i = 0; i < spectralTables.SpectralTables.Count; i++)
            {
                flowLayoutSpectralTable.Controls.Clear();
                DataGridView dg = new DataGridView();
                dg.Size = new Size(220, 350);
                dg.Name = "SpectralTable" + (_DataGridViewisAddedCount + 1).ToString();
                dg.Columns.Add("Wavelength", "Wavelength");
                dg.Columns.Add("Weight", "Relative Weight");
                

                for (int j = 0; j < spectralTables.SpectralTables[i].Numberofpairs; j++)
                {                   
                    int rowId = dg.Rows.Add();
                    DataGridViewRow row = dg.Rows[rowId];
                    SpectralDataPair spectralData = new SpectralDataPair();
                    row.Cells[0].Value = spectralTables.SpectralTables[i].Data[j].Wavelength;
                    row.Cells[1].Value = spectralTables.SpectralTables[i].Data[j].RelativeWeight;
                }
                dg.Dock = DockStyle.Top;
                
                dg.BackgroundColor = Color.LightGray;
                dg.BorderStyle = BorderStyle.Fixed3D;
                dg.AllowUserToAddRows = false;
                dg.AllowUserToDeleteRows = false;
                dg.AllowUserToOrderColumns = true;
                dg.ReadOnly = true;
                dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg.MultiSelect = false;
                dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dg.AllowUserToResizeColumns = false;
                dg.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dg.AllowUserToResizeRows = false;
                dg.RowHeadersVisible = false;
                dg.BorderStyle = BorderStyle.None;
                dg.Columns[0].Width = 100;
                dg.Columns[1].Width = 100;


                flowLayoutSpectralTable.Controls.Add(dg);
                _CurrentDataGridViewName = dg.Name;
                _DataGridViewisAddedCount += 1;
            }
        }

        private void SetDescriptionTab(DescriptionHeaderBlock descriptionHeader)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name of Light Source: ").Append(descriptionHeader.NameOFLightSource.Trim('\0')).AppendLine();
            sb.Append("Manufacturer of Light Source: ").Append(descriptionHeader.ManufacturerOfLightSource.Trim('\0')).AppendLine();
            sb.Append("Creator of Optical Light Source Model: ").Append(descriptionHeader.CreatorofOpticalLightSourceModel.Trim('\0')).AppendLine();
            sb.Append("Creator of the Ray File: ").Append(descriptionHeader.CreatorOfRayFile.Trim('\0')).AppendLine();
            sb.Append("Measurement Equipment / Simulation Software: ").Append(descriptionHeader.Equipment_Software_Used.Trim('\0')).AppendLine();
            sb.Append("Camera Information: ").Append(descriptionHeader.CameraInformation.Trim('\0')).AppendLine();
            sb.Append("Light Source Operation Information: ").Append(descriptionHeader.LightSourceOperationInformation.Trim('\0')).AppendLine();
            sb.Append("Additional Information: ").Append(descriptionHeader.AdditionalInformation.Trim('\0')).AppendLine();
            sb.Append("Data Reference to Light Source Geometry: ").Append(descriptionHeader.DataReferencetoSourceGeometry.Trim('\0')).AppendLine();

            string descriptionString = sb.ToString();
            richTextBoxDecription.Text = descriptionString;

        }

        private void SetFlagTab(KnownDataFlagBlock dataFlags)
        {
            if (dataFlags.PositionFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(0, true);
            }

            if (dataFlags.DirectionFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(1, true);
            }

            if (dataFlags.RadiantFlux_StokesS0Flag == 1)
            {
                checkedListBoxFlags.SetItemChecked(2, true);
            }

            if (dataFlags.WavelengthFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(3, true);
            }

            if (dataFlags.LuminousFlux_TristimulusYFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(3, true);
            }

            if (dataFlags.StokesFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(4, true);
            }

            if (dataFlags.TristimulusFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(5, true);
            }

            if (dataFlags.TristimulusFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(6, true);
            }

            if (dataFlags.SpetrumIndexFlag == 1)
            {
                checkedListBoxFlags.SetItemChecked(7, true);
            }

        }

        private void SetHeaderTab(FileHeaderBlock fileHeaderBlock)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("File Type: ").Append(fileHeaderBlock.FileTypeToASCII()).AppendLine();
            sb.Append("File Version: ").Append(fileHeaderBlock.FileVersion.ToString()).AppendLine();
            if (fileHeaderBlock.CreationMethod == 0)
                sb.Append("Creation Method: ").Append("Simulation").AppendLine();
            else
                sb.Append("Creation Method: ").Append("Measurement").AppendLine();
            sb.Append("Total Luminous Flux: ").Append(fileHeaderBlock.TotalLuminousFlux.ToString()).AppendLine();
            sb.Append("Total Radiant Flux: ").Append(fileHeaderBlock.TotalRadiantFlux.ToString()).AppendLine();
            sb.Append("Number of Rays: ").Append(fileHeaderBlock.NumberOfRays.ToString()).AppendLine();
            sb.Append("File Creation Data: ").Append(fileHeaderBlock.FileCreationDatetoASCII().ToString()).AppendLine();
            sb.Append("Ray Start Position: ").Append(RayStartOptions[fileHeaderBlock.RayStartPosition].ToString()).AppendLine();
            sb.Append("Spectral Data Identifier: ").Append(SpectralDataOptions[fileHeaderBlock.SpectralDataIdentifier].ToString()).AppendLine();
            sb.Append("Single Wavelength: ").Append(fileHeaderBlock.SingleWavelength.ToString()).AppendLine();
            sb.Append("Minimum Wavelength: ").Append(fileHeaderBlock.MinimumWavelength.ToString()).AppendLine();
            sb.Append("Maximum Wavelength: ").Append(fileHeaderBlock.MaximumWavelength.ToString()).AppendLine();
            sb.Append("Number of Spectral Tables: ").Append(fileHeaderBlock.NumberOfSpectralTables.ToString()).AppendLine();
            sb.Append("Number of Additiona Ray Data Items: ").Append(fileHeaderBlock.NumberOfAdditionalRayDataItemsPerRay.ToString()).AppendLine();
            sb.Append("Size of Additional Text Block: ").Append(fileHeaderBlock.SizeOfAdditionalTextBlock.ToString()).AppendLine();
            sb.Append("Reserved for Additional Use: ").AppendLine();

            string headerString = sb.ToString();
            richTextBoxHeader.Text = headerString;
        }

        private Dictionary<int, string> RayStartOptions = new Dictionary<int, String>()
        {
            { 0, "unknown"},
            { 1, "User" },
            { 2, "Plane" },
            { 3, "Sphere" },
            { 4, "Cylinder" },
            { 5, "Cuboid" },
            { 6, "Geometry" },
            { 7, "Back Propogation" }
        };

        private Dictionary<int, string> SpectralDataOptions = new Dictionary<int, String>()
        {
            { 0, "None" },
            { 1, "Single Wavelength" },
            { 2,  "Wavelength Per Ray" },
            { 3,  "Single Spectrum" },
            { 4,  "Spectrum Per Ray" }
        };


    }
}
