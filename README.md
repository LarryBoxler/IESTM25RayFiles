# IESTM25RayFiles
IES TM25-13 Ray File Class Library and Viewer

A C# solution that contains a class library, unit tests, and Windows forms application to parse IES-TM25 ray sets.  Solution Created by Larry Boxler.

Background: Ray files are used for Monte Carlo ray tracing in optical simulation software.  The IES TM-25-13 ray file format is a standardized, flexible and well documented file format. The standard from the IES is available at https://store.ies.org/product/tm-25-20-technical-memorandum-ray-file-format-for-description-of-the-emission-properties-of-light-sources/.  Please note that linked document is the newly released 2020 version.  Any changes made in the 2020 format will not make the 2013 files currently in use inaccessible.  

I wrote this software with the intent of providing a class library to aid in the reading and writing of IES TM25-13 file formats, along with a windows desktop form application that demonstrates the use of the class library for getting the information from a TM25-13 file.  

I make this software available to the community under the "unlicense", see LICENSE, which basically allows you to do whatever you want with the code, except sueing me if it doesn't work for you.

Currently, the software is available as a Visual Studio 2019 project.

I welcome any feedback. Please use the standard GitHub workflow, adding issues, and pull requests if you'd like to provide your own additions / bug fixes.

