[Getting HydroServer](Getting-HydroServer), [Presentations and Publications](Presentations-and-Publications), [Training Materials](Training-Materials)
----
# Getting HydroServer
This page gives instructions on how to access the source code for HydroServer applications.  If you want to download the executable installers, please visit the [Downloads](Downloads) page.

## Downloading Code and Binaries Using Subversion Client
One way to get the HydroServer applications is to use a subversion client tool. We recommend the program, TortoiseSVN, which we believe is being used by most everyone on this project. You can download TortoiseSVN from the following site: [http://tortoisesvn.net/downloads](http://tortoisesvn.net/downloads)

Steps to use TortoiseSVN to get HydroServer include:
# Download the software from [http://tortoisesvn.net/downloads](http://tortoisesvn.net/downloads)
# Install it on your computer (may require a reboot)
# Open a file browser and navigate to the location where you want to place your HydroServer source files
# Right click in that folder and from the context menu that opens select "Subversion Checkout"
# A dialog box will open. In that dialog box enter the following for "URL of Repository": [https://hydroserver.svn.codeplex.com/svn](https://hydroserver.svn.codeplex.com/svn)
# Enter an appropriate local file path where you want to place the files (for example: "c:\dev\hydroserver")
# Click OK. This will initiate a download of the full repository directly to the specified folder, and it will be "set up" for running from that location

## Downloading Code and Binaries as a Zip File
CodePlex provides a link to download the entire source code library. This is done by clicking the "Source Code" tab above, and then on the right hand side, you will see a box that says "Latest Version". In that box is a link that says "Download". Click that link. This will initiate a full download of the entire HydroServer Subversion Code Repository (after you agree to the HydroServer open source license). Alternatively, you can click on a the "Browse" link in that same "Latest Version" box. This will take you to a file and code browser for the full repository. That page shows a list of files and folders on the lefthand side and includes another "Download" link that will also initiate a full download of a zip file of the full repository.

## Executing HydroServer from the Source Code Repository
Once TortoiseSVN completes, or if you download the source code file and unzip it to your folder, then you can navigate to the folder where you placed the files, and either run the executable from the binaries folders, or open the Visual Studio 2008 solution file to work on the source code and execute the application from within Visual Studio.

## Committing Your Changes to the Repository
If you make any changes to the source code and you want to commit those to the repository (assuming you have developer privileges for this project), then simply right click in the folder where you have your HydroServer files, and click "SVN Commit". Note that this only works if you used TortoiseSVN to download the code in the first place. PLEASE Comment your commits. It is critical to project management that every code change is commented in the TortoiseSVN commit window. It can be a brief comment "Changed appearance of X" or "Changed behavior of Y" but it just needs to be there.

If you do not have privileges to commit code to this project and would like to be given privileges, please register with CodePlex and then send your user name to the project manager (user: jcullen). 