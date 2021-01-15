<h1>TUTORIAL: Create and run a Windows Service in C#</h1>

[Microsoft Windows Services](https://docs.microsoft.com/en-us/dotnet/framework/windows-services/introduction-to-windows-service-applications) enable you to create long-running executable applications that run in their own Windows sessions. These services can be automatically started when the computer boots, can be paused and restarted, and do not show any user interface.


<h2>Initial steps</h2>

The first step to create a service - in the easiest way - is to have installed [Visual Studio](https://visualstudio.microsoft.com/pt-br/) on your machine. Differently of VS Code, in Visual Studio you can work with compilated languages, without to perform several steps before. VS Code it's best if you are working with web and cloud applications or using just a text editor. In our case, we're using Visual Studio because it have great templates to console and windows apps, with both C# or VB configurations.

Now, open Visual Studio, go to File > New and select Project. Now, select the project template. In this case, Windows Service usign C#. Give a name, choose location and click Create.


<h3>Configuring Installer</h3>

A blank screen will appear, so you right click on it and select [Add Installer](https://docs.microsoft.com/en-us/dotnet/framework/windows-services/how-to-add-installers-to-your-service-application). You need to install it, because it will register the service on the system and let the Services Control Manager know that the service exists. 

After, ProjectInstaller class and two components, ServiceProcessInstaller and ServiceInstaller, will add to your project.

__ProjectInstaller.cs__ file will be open. Right click selecting View Code and look for the InitializeComponent method. 

    public ProjectInstaller()
        {
            InitializeComponent();
        }

This method contains the logic which creates and initializes the user interface objects dragged on the forming surface and provided the Property Grid of Form Designer. Select Shift+click on it to define it, opening the file __ProjectInstaller.Design.cs__. 

Inside the *InitializeComponent*, below *// serviceProcessInstaller1*, add this line:
    
    this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;

If you want to, after *// serviceInstaller1*, add descrption and the display name of your service. As mine:

        this.serviceInstaller1.Description = "A service for ...";  
        this.serviceInstaller1.DisplayName = "Name who'll appears on Services list";  


<h3>Write your code on Service1.cs Class</h3>

Now, in the __Service1.cs__ file, you can write the Service code. 
This is a example of [code](https://github.com/amandafrois/windows_services/blob/main/Service1.cs), that I've created to a Service who generates keys in new .txt files, 10 seconds.

After you finished, Build (or Rebuild) your application, right-clicking on your project solution.

<h3>Adding your code as a Service</h3>

Now, run the Commmand prompt (cmd) as Administrator.

Run the command to enter in the __InstallUtil.exe__ folder. Is something like that:

    cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319>

Now, go to your project source folder. Get the path of file into Debug folder. Mine was that:

     C:\Users\AMANDA\source\repos\Amandapplication\bin\Debug\Amandapplication.exe

On command prompt, into the folder, run: 

    InstallUtil.exe Your application path

Mine was:

    C:\Windows\Microsoft.NET\Framework64\v4.0.30319>Installutil /u C:\Users\AMANDA\source\repos\Amandapplication\bin\Debug\Amandapplication.exe

Now, if your code is working well, you'll see your app service on Services (msc). Start it and enjoy :)
