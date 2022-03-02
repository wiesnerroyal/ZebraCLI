# ZebraCLI
A simple command line interface for Zebra-Printer</br>
<p align="center">
  <img src="https://raw.githubusercontent.com/wiesnerroyal/ZebraCLI/main/img/view.png" />
</p>

## Info:
You can read and change the Printer-Settings over TCP/IP.
The commands are based on the ZPL II standard. You can find more informations about ZPL II on Wiki [here](https://en.wikipedia.org/wiki/Zebra_Programming_Language) or in the ZPL II Programming Guide [here](https://www.zebra.com/content/dam/zebra/manuals/printers/common/programming/zpl-zbi2-pm-en.pdf). The program was tested with a ZE500 Print Engine.

## how-to:
Zebra-CLI is straightforward. Start the precompiled ZebraCLI.exe in "/bin/Debug/net5.0" via CMD or Powershell and follow the insructions.
```sh
/bin/Debug/net5.0/ZebraCLI.exe
```
You can customize the View.cs and ZebraCLI.cs files to predefine your own commands or send any ASCII-Data with "Custom Command".
