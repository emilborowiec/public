# Setting up for java dev on windows with Chocolatey

This guide shows steps for complete setup of windows 
machine for developing java applications.

Traditionally, software packages on windows are installed by manually downloading
them from their web pages. This takes time and is too fiddly when compared to using
package managers such as yum. Fortunatelly there is Chocolatey, which brings some
of this experience.

## Install Choclolatey 
Run this command as admin

```
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command " [System.Net.ServicePointManager]::SecurityProtocol = 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"
```

If you already had it installed you might want to update it
and then update already installed packages and see what's actually installed

```
choco upgrade chocolatey
choco list --local-only
choco outdated
choco upgrade all
```

## Install Java Open JDK

```
choco install openjdk
```

Add openjdk bin directory to path (has to be done manually). The example path will be

```
C:\Program Files\OpenJDK\jdk-14.0.1\bin
```

Next, you can optionally add java api sources and documentation.
If you open new terminal after installing java, you can use 'jar' command
for unpacking archives. 

```
mkdir %userprofile%/javasrc
cd %userprofile%/javasrc
jar xvf "%JAVA_HOME%/lib/src.zip"
```

For documentation you need to manually download it from:
https://www.oracle.com/java/technologies/javase-downloads.html

Unpack, open index.html in your browser and add a bookmark.

## Install notepad++

```
choco install notepadplusplus
```

## Install git client

```
choco install git.install --params "/GitOnlyOnPath /SChannel /NoGitLfs /NoShellIntegration"
```

This installs git with following options:
- Puts git on PATH but not the additional tools
- Uses windows native ssl/tls implementation and not OpenSSL
- No git large file storage installation (not needed for most development)
- No windows explorer integration
- core.autocrlf set to true
- Use Git Credential Manager

I'm not good at vim, so I set default editor to notepad++.
```
git config --global core.editor "notepad++  -multiInst -notabbar -nosession -noPlugin"
```

## Install sourcetree - git GUI
```
choco install sourcetree
```

## Install JetBrains IntelliJ Idea

For free community edition run
```
choco install intellijidea-community
```
And for ultimate
```
choco install intellijidea-ultimate
```

## Install Maven
```
choco install maven
```
