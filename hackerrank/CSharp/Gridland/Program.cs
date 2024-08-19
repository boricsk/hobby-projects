/*
A Gridland Királyság P tartományokat tartalmaz. Minden tartomány 2 X N-es rácsként van meghatározva, 
ahol a rács minden cellája egy várost jelöl. A rács minden cellája tartalmaz egy kisbetűt, 
amely az adott cellának megfelelő városnév első karakterét jelöli.

Az (i,j) koordinátákkal rendelkező városból 1 időegység alatt a következő cellák bármelyikébe 
lehet lépni (feltéve, hogy a célcella a rács határain belül van):

(i-1, j)
(i+1, j)
(i, j-1)
(i, j+1)

Egy lovag meg akarja látogatni Gridland összes városát. Bármely városban megkezdheti az utazást, 
és azonnal abbahagyja az utazást, miután minden várost legalább egyszer meglátogatott. 
Sőt, utazását mindig úgy tervezi meg, hogy annak teljesítéséhez szükséges teljes idő minimális legyen.

Miután befejezte az egyes tartományokban tett körútját, a lovag az útjába kerülő összes 
cella karaktereit összefűzve zsinórt alkot. 
Hány különböző karakterláncot alkothat az egyes tartományokban?

Az első sor egyetlen egész számot tartalmaz, P , amely a tartományok számát jelöli. 
A következő 3*P sorok mindegyik tartományt a következő három sorban írják le:
Az első sor egy N egész számot tartalmaz, amely a tartomány oszlopainak számát jelöli.
A következő két sor mindegyike tartalmaz egy N hosszúságú S karakterláncot, 
amely a tartomány első és második sorának karaktereit jelöli.

 */
