# Rapport Bender -Even tom
## PIECE
- Dans un premier temps, je supprime le cube de base et j'ajoute un cylindre.  
- Ensuite, j’aplatis le cylindre sur l’axe Z.  
- Je sélectionne les faces supérieure et inférieure, puis j’appuie sur **I** pour créer un cercle plus petit au centre.  
- J’extrude ces faces avec **E** (sans déplacer la souris), puis j’utilise **S** et **Z** pour les enfoncer tout en gardant les bords intacts.  
- J’ajoute le texte « Æ », je le place au centre et j’ajuste sa taille.  
- Je mets un modificateur **Solidify** sur le texte avec une épaisseur de 0.2 m.  
- Je transforme le texte en maillage (mesh) via **Object → Convert → Mesh**.  
- Sur ma pièce, j’ajoute un modificateur **Booléen** en mode Différence, et je choisis le texte comme objet pour percer la forme.  
- Je sélectionne les arêtes que je veux arrondir avec **Alt + Clic**, puis je les arrondis avec **CTRL + B**.  
- Enfin, je crée un matériau jaune doré, je règle le paramètre métallique à 1 pour qu’il soit bien brillant, et je mets la rugosité à 0.3 pour qu’il brille sans être trop lisse.  


## CLEF
- Pour modéliser mon logo, je place l’image qui va me servir de guide en fond. Cela me permet de prendre un cube et d’extruder, puis de redimensionner une face pour suivre les contours de mon logo.  
- Je positionne donc le logo, j’ajoute un cylindre que j’arrondis d’un côté, puis je crée un cube pour former la partie qui va entrer dans la serrure.  
- Pour modifier ce cube, je divise ses faces avec **Ctrl + R** en mode Edit, puis je supprime la face du milieu.  
- Pour éviter d’avoir un objet creux, je sélectionne les arêtes autour du trou et, avec **F**, je rajoute des faces.  
- Enfin, je crée un matériau doré et l’applique à ma clé.  

## Tonneau
- Je commence par créer un cube que je dimensionne dans tous les axes pour lui donner l’apparence d’une planche.  
- J’utilise **Ctrl + R** pour ajouter des arêtes qui me serviront à plier la planche plus tard.  
- J’applique ensuite un **Simple Deform** pour courber ma planche.  
- J’ajoute un objet **Empty** et je le tourne légèrement sur l’axe Z permettant.  
- Je mets un modificateur **Array** sur ma planche avec comme **Object Offset** l’objet **Empty**, puis je règle le nombre de planches et je déplace ma planche sur l’axe Y pour obtenir l’écartement souhaité.  
- J’ajoute un cylindre, je le déplace au-dessus de mes planches et je le redimensionne pour qu’il soit fin sur l’axe Z. Ensuite, je l’ajuste pour que ses côtés épousent la forme de mes planches.  
- J’applique un modificateur **Mirror** avec comme **Mirror Object** l’objet **Empty** pour que le cylindre se duplique en haut et en bas de mes planches.  
- Pour le dessus, j’ajoute un cube, je le dimensionne comme une planche à plat, puis je le place en haut de mon tonneau.  
- J’applique un modificateur **Array** avec un **Constant Offset** de 0.01 sur l’axe X.  
- Je mets un modificateur **Mirror** sur l’axe Z et j’utilise mon objet **Empty** pour dupliquer mes planches également sous le tonneau.  
- Enfin, pour transformer le dessus de mon tonneau en forme circulaire, j’ajoute un cylindre dont le diamètre correspond à celui du haut du tonneau, puis j’applique un modificateur **Boolean** en mode **Intersection** entre ma plaque de planche et ce cylindre.  

## Suzanne
- Pour texturer Suzanne, je commence par sélectionner les arêtes du modèle dans Blender afin de créer des découpes et générer une UV Map.  
- Une fois la carte UV obtenue, je l’exporte au format PNG.  
- Dans Krita, j’importe cette UV Map et je crée deux calques : un pour l’UV en tant que guide et un autre pour les couleurs.  
- Ensuite, grâce à la sélection polygonale, je suis les formes de mon modèle pour appliquer une UV Map colorée.  
- Enfin, je l’applique dans Blender en tant que **Base Color** dans un matériau.  
