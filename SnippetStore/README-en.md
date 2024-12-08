## Borics Krisztián
### Snippet Store

Have you ever faced a situation during a large project where you needed to solve a problem you had already tackled before? In such cases, you usually end up searching through thousands of lines of code, trying to locate the relevant snippet. This app aims to provide a solution to that issue. With its help, you can save your code snippets to a local or cloud-based (Atlas) MongoDB database and perform quick searches to find them when needed.

### Preparations Before Installation
If you want to use the app with a locally installed database, you'll need to install MongoDB, which will run as a service on your system. You can download the installer and find installation instructions here: [ MongoDb Community Server Download ](https://www.mongodb.com/try/download/community)
For cloud-based usage, you need to register with the service provider. I recommend MongoDB Atlas, which is free up to 512MB of database size. [ MongoDb Atlas ](https://www.mongodb.com/products/platform/atlas-database)

### Installation
You can install the app either via the installer or by compiling the code yourself after downloading it. In both cases, you'll need .NET to run the application, which can be downloaded from Microsoft's website: [ .NET Download ](https://dotnet.microsoft.com/en-us/download) Once installed, you can launch the program using the desktop shortcut.
The installer is available for download here: <br> [ Snippet Store Setup Download ](https://devnullsec.hu/bin/setup.zip)<br>

### Main interface

<img src=./pic/scr-main.jpg >
<br><br>
The toolbar buttons provide the following functionalities:

    Add a new snippet
    Settings
    Delete a snippet
    Save snippet modifications
    Discard snippet modifications
    Expand tree view
    Collapse tree view
    Copy snippet
    Copy data from the cloud database to the local database

On the left, snippets in the database are grouped by language. In the top-right section, you'll find the snippet editor, while the bottom-right section provides a small statistical overview, including the proportion of languages in the database and a top 5 views statistic.

### Settings
<img src=./pic/scr-setup-1.jpg ><br><br>

Before using the app, you must add the programming languages you want to work with. This can be done in the "Add Language" section. You can also define keywords, which will be available when adding snippets and will improve search efficiency.<br><br>
Syntax tab<br>
<img src=./pic/scr-setup-2.jpg ><br><br>
The app includes basic syntax highlighting. In the "Add Reserved Word" section, you can specify words you'd like to see highlighted in a specific color in the editor. The same applies to "Add Block Separator."
On the right side, you need to configure the connection strings for databases. If "Use Local Database" is checked, the app will use the local database. Changing this setting requires restarting the app. Don’t forget to click "Save Config" to save your changes.


### Adding Snippets
<img src=./pic/scr-add-snip.jpg ><br><br>

1. Select a programming language from the list (these are the languages you added in the settings).
2. Add keywords using the >> button. Use the - button to remove selected keywords from the list. The list on the right will display the keywords to be saved to the database. Use the green search bar to filter keywords. Keywords can be permanently removed in the settings.
3. Give the snippet a name.
4. Optionally, add a longer description.
5. Paste your code and click "Add to Database" to save.

Duplicate snippet names are not allowed. If a duplicate name exists, it will be highlighted with a red background. Note that image insertion is not supported in this version.<br>
<img src=./pic/scr-exist-snip.jpg ><br><br>


### Search
<img src=./pic/scr-find.jpg ><br><br>

Enter the search term in the text box above the tree view. Note that searches are case-sensitive. Use the "Clear Search" button to reset the view, displaying all snippets again.

### Delete
<img src=./pic/scr-del-snip.jpg ><br><br>

When you select a snippet, the delete button becomes active. Clicking it will delete the selected snippet.

### Modifying Snippets
<img src=./pic/scr-mod-snip.jpg ><br><br>

To edit a snippet, double-click in the snippet editor window. The two buttons at the top will activate. Once you've made your changes, click "Save Changes" to save them or "Cancel Changes" to discard them.

### Others
<img src=./pic/scr-oth-btn.jpg ><br><br>

A funkciók rendre a következőek:

1. Expand the entire tree view.
2. Collapse the tree view.
3. Copy a snippet to the clipboard.
4. Copy data from the cloud database to the local database (requires a local MongoDB service).
5. Clear the search field.

### Support Me

If you enjoyed this program and would like to support my future work, you can do so here:

1.  [ Patreon ](https://www.patreon.com/c/user?u=67730415)
2.  RevTag : @chris314
