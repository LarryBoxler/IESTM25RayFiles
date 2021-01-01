using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace IESTM25RayFiles
{
    public class IESTM25File
    {
        public FileHeaderBlock FileHeader { get; set; }
        public KnownDataFlagBlock DataFlags { get; set; }
        public DescriptionHeaderBlock DescriptionHeader { get; set; }
        public SpectralTableBlock SpectralTables { get; set; }
        public AdditionalRayDataColumnLabelsBlock AdditionalRayDataColumnLabels { get; set; }
        public AdditionalTextBlock AdditionalText { get; set; }
        public RayDataLinesBlock RayData { get; set; }

        public IESTM25File(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                FileHeaderBlock fileHeader = new FileHeaderBlock();
                ReadHeaderBlock(reader, ref fileHeader);
                if (!fileHeader.CheckHeaderBlockisValid())
                    throw new InvalidTM25Exception("Header Block Not Correct Size", "");
                FileHeader = fileHeader;
   
                KnownDataFlagBlock knownDataFlag = new KnownDataFlagBlock();
                ReadDataFlagBlock(reader, ref knownDataFlag);
                if (!knownDataFlag.CheckKnownDataFlagBlockisValid())
                    throw new InvalidTM25Exception("Data Flag Block Not Correct Size", "");
                DataFlags = knownDataFlag;

                DescriptionHeaderBlock descriptionHeader = new DescriptionHeaderBlock();
                ReadDescriptionHeaderBlock(reader, ref descriptionHeader);
                if (!descriptionHeader.CheckDescriptionBlockisValid())
                    throw new InvalidTM25Exception("Description Header Block is Not Correct Size", "");
                DescriptionHeader = descriptionHeader;   
                
                if(FileHeader.NumberOfSpectralTables > 0)
                {
                    SpectralTableBlock spectralTables = new SpectralTableBlock();
                    spectralTables.SpectralTables = new List<SpectralTable>();
                    ReadSpectralTableBlock(reader, ref spectralTables);
                    if(!spectralTables.CheckSpectralTableisValid())
                        throw new InvalidTM25Exception("Spectral Table Block is Not Correct Size", "");
                    SpectralTables = spectralTables;
                }

                if(FileHeader.NumberOfAdditionalRayDataItemsPerRay > 0)
                {
                    AdditionalRayDataColumnLabelsBlock columnLabelsBlock = new AdditionalRayDataColumnLabelsBlock();                   
                    ReadColumnsLabelsBlock(reader, ref columnLabelsBlock);
                    if (!columnLabelsBlock.CheckAdditionalRayDataColumnisValid())
                        throw new InvalidTM25Exception("Additional Ray Data Columns Block is incorrect");
                    AdditionalRayDataColumnLabels = columnLabelsBlock;
                }

                if(FileHeader.SizeOfAdditionalTextBlock > 0)
                {
                    AdditionalTextBlock additionalTextBlock = new AdditionalTextBlock();
                    ReadAdditionalTextBlock(reader, ref additionalTextBlock);
                    AdditionalText = additionalTextBlock;
                }

                RayDataLinesBlock rayDataLines = new RayDataLinesBlock();
                rayDataLines.Rays = new float[FileHeader.NumberOfRays][];
                ReadRayDataBlock(reader, ref rayDataLines);
                rayDataLines.RayDataMembers = TM25HelperFunctions.GetListofRayDataFieldsPresent(DataFlags, FileHeader, AdditionalRayDataColumnLabels);
                RayData = rayDataLines;

            }
        }

        public IESTM25File(string fileName, ulong numrays)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                FileHeaderBlock fileHeader = new FileHeaderBlock();
                ReadHeaderBlock(reader, ref fileHeader);
                if (!fileHeader.CheckHeaderBlockisValid())
                    throw new InvalidTM25Exception("Header Block Not Correct Size", "");
                FileHeader = fileHeader;

                KnownDataFlagBlock knownDataFlag = new KnownDataFlagBlock();
                ReadDataFlagBlock(reader, ref knownDataFlag);
                if (!knownDataFlag.CheckKnownDataFlagBlockisValid())
                    throw new InvalidTM25Exception("Data Flag Block Not Correct Size", "");
                DataFlags = knownDataFlag;

                DescriptionHeaderBlock descriptionHeader = new DescriptionHeaderBlock();
                ReadDescriptionHeaderBlock(reader, ref descriptionHeader);
                if (!descriptionHeader.CheckDescriptionBlockisValid())
                    throw new InvalidTM25Exception("Description Header Block is Not Correct Size", "");
                DescriptionHeader = descriptionHeader;

                if (FileHeader.NumberOfSpectralTables > 0)
                {
                    SpectralTableBlock spectralTables = new SpectralTableBlock();
                    spectralTables.SpectralTables = new List<SpectralTable>();
                    ReadSpectralTableBlock(reader, ref spectralTables);
                    if (!spectralTables.CheckSpectralTableisValid())
                        throw new InvalidTM25Exception("Spectral Table Block is Not Correct Size", "");
                    SpectralTables = spectralTables;
                }

                if (FileHeader.NumberOfAdditionalRayDataItemsPerRay > 0)
                {
                    AdditionalRayDataColumnLabelsBlock columnLabelsBlock = new AdditionalRayDataColumnLabelsBlock();
                    ReadColumnsLabelsBlock(reader, ref columnLabelsBlock);
                    if (!columnLabelsBlock.CheckAdditionalRayDataColumnisValid())
                        throw new InvalidTM25Exception("Additional Ray Data Columns Block is incorrect");
                    AdditionalRayDataColumnLabels = columnLabelsBlock;
                }

                if (FileHeader.SizeOfAdditionalTextBlock > 0)
                {
                    AdditionalTextBlock additionalTextBlock = new AdditionalTextBlock();
                    ReadAdditionalTextBlock(reader, ref additionalTextBlock);
                    AdditionalText = additionalTextBlock;
                }

                RayDataLinesBlock rayDataLines = new RayDataLinesBlock();
                rayDataLines.Rays = new float[FileHeader.NumberOfRays][];
                ReadPartialRayDataBlock(reader, ref rayDataLines, numrays);
                rayDataLines.RayDataMembers = TM25HelperFunctions.GetListofRayDataFieldsPresent(DataFlags, FileHeader, AdditionalRayDataColumnLabels);
                RayData = rayDataLines;

            }
        }

        private void ReadRayDataBlock(BinaryReader reader, ref RayDataLinesBlock rayDataLines)
        {
            var numberofRayDataFields = TM25HelperFunctions.FindNumberOfRayDataFields(DataFlags, FileHeader);
            for (ulong i = 0; i < FileHeader.NumberOfRays; i++)
            {
                rayDataLines.Rays[i] = new float[numberofRayDataFields];
                for (int j = 0; j < numberofRayDataFields; j++)
                {
                    rayDataLines.Rays[i][j] = reader.ReadSingle();
                }
            }
        }
        
        private void ReadPartialRayDataBlock(BinaryReader reader, ref RayDataLinesBlock rayDataLines, ulong numrays)
        {
            var numberofRayDataFields = TM25HelperFunctions.FindNumberOfRayDataFields(DataFlags, FileHeader);
            for (ulong i = 0; i < numrays; i++)
            {
                rayDataLines.Rays[i] = new float[numberofRayDataFields];
                for (int j = 0; j < numberofRayDataFields; j++)
                {
                    rayDataLines.Rays[i][j] = reader.ReadSingle();
                }
            }
        }

        private void ReadAdditionalTextBlock(BinaryReader reader, ref AdditionalTextBlock additionalTextBlock)
        {
            if (FileHeader.SizeOfAdditionalTextBlock % 32 != 0)
                throw new InvalidTM25Exception("Additional text block size is not a multiple of 32", FileHeader.SizeOfAdditionalTextBlock.ToString());
            additionalTextBlock.AdditionalText = new string(reader.ReadChars(FileHeader.SizeOfAdditionalTextBlock));
        }

        private void ReadColumnsLabelsBlock(BinaryReader reader, ref AdditionalRayDataColumnLabelsBlock columnLabelsBlock)
        {
            columnLabelsBlock.ColumnNames = new List<string>();
            for (int i = 0; i < FileHeader.NumberOfAdditionalRayDataItemsPerRay; i++)
                columnLabelsBlock.ColumnNames.Add(new string(reader.ReadChars(512)));
        }

        private void ReadSpectralTableBlock(BinaryReader reader, ref SpectralTableBlock spectralTableBlock)
        {
            int tableBlockSize = 0;
            for (int i = 0; i < FileHeader.NumberOfSpectralTables; i++)
            {
                SpectralTable table = new SpectralTable();
                table.Numberofpairs = reader.ReadInt32();
                if (table.Numberofpairs <= 0)
                    throw new InvalidTM25Exception("Number of DataPairs must be > 0");
                table.Data = new List<SpectralData>();
                tableBlockSize += 4 * ((2 * table.Numberofpairs) + 1);
                for (int j = 0; j < table.Numberofpairs; j++)
                {
                    SpectralDataPair dataPair = new SpectralDataPair();
                    dataPair.Wavelength = reader.ReadSingle();
                    if (dataPair.Wavelength <= 0.0)
                        throw new InvalidTM25Exception("Spectral Data Wavelength Cannot be 0 or negative");
                    dataPair.RelativeWeight = reader.ReadSingle();
                    if (dataPair.RelativeWeight < 0.0)
                        throw new InvalidTM25Exception("Relative Weights Cannot be negative");
                    table.Data.Add(dataPair);
                }
                spectralTableBlock.SpectralTables.Add(table);
            }

            if (tableBlockSize % 32 != 0)
            {
                int numberToPad = (((tableBlockSize / 32) + 1) * 32 - tableBlockSize) / 4;
                for (int i = 0; i < numberToPad; i++)
                {
                    reader.ReadSingle();
                    spectralTableBlock.SpectralTables[FileHeader.NumberOfSpectralTables - 1].Data.Add(new SpectralPadding());
                }
            }
        }

        private void ReadDescriptionHeaderBlock(BinaryReader reader, ref DescriptionHeaderBlock descriptionHeader)
        {
            byte[] buffer = reader.ReadBytes(4000);
            descriptionHeader.NameOFLightSource = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.ManufacturerOfLightSource = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.CreatorofOpticalLightSourceModel = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.CreatorOfRayFile = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.Equipment_Software_Used = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.CameraInformation = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.LightSourceOperationInformation = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.AdditionalInformation = Encoding.UTF32.GetString(buffer);
            buffer = reader.ReadBytes(4000);
            descriptionHeader.DataReferencetoSourceGeometry = Encoding.UTF32.GetString(buffer);
        }

        private void ReadDataFlagBlock(BinaryReader reader, ref KnownDataFlagBlock knownDataFlag)
        {
            var intbuffer = reader.ReadInt32();
            if (intbuffer != 1)
                throw new InvalidTM25Exception("Position Flag Must be 1", intbuffer.ToString());
            knownDataFlag.PositionFlag = intbuffer;

            intbuffer = reader.ReadInt32();
            if (intbuffer != 1)
                throw new InvalidTM25Exception("Direction Flag Must be 1", intbuffer.ToString());
            knownDataFlag.DirectionFlag = intbuffer;

            var radiantFluxFlag = reader.ReadInt32();

            intbuffer = reader.ReadInt32();
            if (intbuffer > 1)
                throw new InvalidTM25Exception("Wavelength Flag not 0 or 1", intbuffer.ToString());
            if (FileHeader.SpectralDataIdentifier == 2 && intbuffer == 0)
                throw new InvalidTM25Exception("Wavelength Flag not Present", intbuffer.ToString());
            knownDataFlag.WavelengthFlag = intbuffer;

            var luminousFluxFlag = reader.ReadInt32();
            var stokesFlag = reader.ReadInt32();
            var tristimulusFlag = reader.ReadInt32();

            intbuffer = reader.ReadInt32();
            if(intbuffer > 1)
                throw new InvalidTM25Exception("Spectrum Index Flag not 0 or 1", intbuffer.ToString());
            if (FileHeader.SpectralDataIdentifier == 4 && intbuffer == 0)
                throw new InvalidTM25Exception("Spectrum Index Flag Not Correct", intbuffer.ToString());
            if (FileHeader.SpectralDataIdentifier != 4 && intbuffer == 1)
                throw new InvalidTM25Exception("Spectrum Index Flag Not Correct", intbuffer.ToString());
            knownDataFlag.SpetrumIndexFlag = intbuffer;

            if (radiantFluxFlag == 0 && luminousFluxFlag == 0)
                throw new InvalidTM25Exception("Radiant Flux Flag Not Correct", radiantFluxFlag.ToString());
            if (stokesFlag == 1 && radiantFluxFlag == 0)
                throw new InvalidTM25Exception("Radiant Flux Flag Not Correct", radiantFluxFlag.ToString());
            if ((FileHeader.SpectralDataIdentifier == 2 || FileHeader.SpectralDataIdentifier == 4) && radiantFluxFlag == 0)
                throw new InvalidTM25Exception("Radiant Flux Flag Not Correct", radiantFluxFlag.ToString());
            if (radiantFluxFlag > 1)
                throw new InvalidTM25Exception(@"Radiant Flux/Stokes So  Flag not 0 or 1", intbuffer.ToString());
            knownDataFlag.RadiantFlux_StokesS0Flag = radiantFluxFlag;
            knownDataFlag.StokesFlag = stokesFlag;

            if (tristimulusFlag == 1 && luminousFluxFlag == 0)
                throw new InvalidTM25Exception("Luminous Flux Flag Not Correct", luminousFluxFlag.ToString());
            if ((FileHeader.SpectralDataIdentifier == 2) || (FileHeader.SpectralDataIdentifier == 4))
                luminousFluxFlag = 0;
            knownDataFlag.LuminousFlux_TristimulusYFlag = luminousFluxFlag;

            if (tristimulusFlag == 1 && FileHeader.SpectralDataIdentifier != 0)
                throw new InvalidTM25Exception("Tristimulus Data is only allowed if Spectral Data Identifier = 0", tristimulusFlag.ToString());
            knownDataFlag.TristimulusFlag = tristimulusFlag;



        }
       
        private void ReadHeaderBlock(BinaryReader reader, ref FileHeaderBlock fileheader)
        {
            var bytebuffer = reader.ReadBytes(4);
            var text = System.Text.Encoding.ASCII.GetString(bytebuffer);
            if (text != "TM25")
                throw new InvalidTM25Exception("FileType is not TM25", text);
            fileheader.FileType = bytebuffer;

            var intbuffer = reader.ReadInt32();
            if (intbuffer != 2013)
                throw new InvalidTM25Exception("File Version is not 2013", intbuffer.ToString());
            fileheader.FileVersion = intbuffer;

            fileheader.CreationMethod = reader.ReadInt32();
            fileheader.TotalLuminousFlux = reader.ReadSingle();
            fileheader.TotalRadiantFlux = reader.ReadSingle();
            fileheader.NumberOfRays = reader.ReadUInt64();
            fileheader.FileCreationDateAndTime = reader.ReadBytes(28);
            fileheader.RayStartPosition = reader.ReadInt32();

            intbuffer = reader.ReadInt32();
            if (intbuffer > 4 || intbuffer < 0)
                throw new InvalidTM25Exception("Spectral Data Identifier Not Valid", intbuffer.ToString());
            fileheader.SpectralDataIdentifier = intbuffer;

            var floatbuffer = reader.ReadSingle();
            if (fileheader.SpectralDataIdentifier == 1 && floatbuffer < 0)
                throw new InvalidTM25Exception("Single Wavelength Not Valid", floatbuffer.ToString());

            fileheader.MinimumWavelength = reader.ReadSingle();
            fileheader.MaximumWavelength = reader.ReadSingle();

            intbuffer = reader.ReadInt32();
            if ((fileheader.SpectralDataIdentifier == 3 || fileheader.SpectralDataIdentifier == 4) && intbuffer < 1)
                throw new InvalidTM25Exception("Number of Spectral Tables Not Valid", intbuffer.ToString());
            fileheader.NumberOfSpectralTables = intbuffer;

            intbuffer = reader.ReadInt32();
            if (intbuffer < 0)
                throw new InvalidTM25Exception("Number of Additional Ray Data Items Not Valid", intbuffer.ToString());

            intbuffer = reader.ReadInt32();
            if (intbuffer % 32 != 0 || intbuffer < 0)
                throw new InvalidTM25Exception("Size of Additional Text Block Not Valid", intbuffer.ToString());

            reader.ReadBytes(168);
        }
    }


}
