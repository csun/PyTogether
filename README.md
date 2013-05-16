PyTogether
==========

PyTogether is a python-enabled chat program. Essentially, every person connected to the server has access to a communal python interpreter. Users are free to create new "Channels", which also represent new scopes to execute code in (a clean slate for any new code you want to write over the network).

PyTogether is written in C#, and depends heavily on the .NET libraries, as well as on [IronPython](http://ironpython.net/).

Please beware that currently any client connected to a server can execute any syntactically legal python code they want, including code that may pose a threat to the server. This is the nature of the program, and while I hope to introduce features in the future that can negate some of the dangers, they will never be completely eliminated. Please host servers at your own risk.

Instructions
============

The interface should be fairly self explanatory. Inject means that any message you send is not treated as a message, and is instead treated as a complete block of code, and injected into the interpreter. The only thing not represented in the interface is the ability to write "escaped" code. Writing escaped code involves using any python expression that evaluates to a string, and putting the aforementioned string directly into a sent message. For example, when sending the following message:

    Two plus two equals /*str(2+2)*/

Any clients who receive the message will see

    Two plus two equals 4

This is because `str(2+2)` successfully evaluates to the string `"4"` in the in the interpreter. The current strings used to surround escaped code are `/*` and `*/`.


To specify the directories that the server searches when importing modules, create a file called `import_paths.cfg`, and populate it with the global paths that you want the server to search (one path per line).


Building
========

PyTogether is programmed using Visual Studio 2012, .NET 4.5, and IronPython 2.7. All the files needed to build the project should be included in the repo for users of VS2012. I have not tried compiling in an environment like mono, and I'm not sure it would work, but if it works for you, I'd love to hear about it.

Have fun!  
-igpay
