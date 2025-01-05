# Modélisation de Pièce

## Étapes :
1. **Créer la forme de base :**
    - Aplatir un cylindre sur l’axe Z.

2. **Créer l’encoche centrale :**
    - Sélectionner les faces du dessus et du dessous, appuyer sur `I` pour insérer un cercle plus petit au centre.
    - Extruder avec `E` sans déplacer la souris, puis appuyer sur `S` et `Z` pour enfoncer les faces sans déformer les bords.

3. **Ajouter le logo :**
    - Ajouter une image du logo en fond.
    - Prendre un cube, extruder et redimensionner pour recréer le logo.
    - Placer ce logo sur la pièce.
    - Appliquer un **Boolean Modifier** en mode `Différence` avec le logo comme objet booléen.

4. **Arrondir les bords :**
    - Sélectionner les arêtes avec `Alt + Click`.
    - Appuyer sur `CTRL + B` pour arrondir.

5. **Texturage :**
    - Créer un nouveau matériau avec :
        - **Base Color :** Jaune doré
        - **Metallic :** `1.0`
        - **Roughness :** `0.3` pour limiter l'effet miroir

---

# Modélisation de Tonneau

## Étapes :
1. **Créer une planche :**
    - Créer un cube et le dimensionner pour qu’il ressemble à une planche.
    - Ajouter des arêtes avec `CTRL + R` pour plier la planche.
    - Appliquer un **Simple Deform Modifier** de `30°` pour courber.

2. **Dupliquer en cercle :**
    - Ajouter un `Empty Object` et le tourner légèrement sur l’axe Z.
    - Appliquer un **Array Modifier** à la planche avec l’empty comme `Object Offset`.
    - Ajuster le nombre de planches et l’écartement sur l’axe Y.

3. **Créer les cercles de renfort :**
    - Ajouter un cylindre, le redimensionner sur l’axe Z, et l’ajuster à la forme des planches.
    - Appliquer un **Mirror Modifier** avec l’empty pour dupliquer en haut et en bas.

4. **Ajouter des clous :**
    - Créer un cylindre pour représenter un clou.
    - Appliquer un **Array Modifier** avec l’empty pour dupliquer tout autour du tonneau.
    - Appliquer un **Mirror Modifier** pour ajouter des clous en bas.

5. **Fabriquer le dessus et le dessous :**
    - Créer un cube, le dimensionner pour qu’il ressemble à une planche à plat.
    - Appliquer un **Array Modifier** avec un `Constant Offset` de `0.01` sur l’axe X.
    - Appliquer un **Mirror Modifier** sur l’axe Z avec l’empty.
    - Ajouter un cylindre de la taille du dessus du tonneau et appliquer un **Boolean Modifier** en mode `Intersection`.

6. **Texture :**
    - je me suis aidé de cette [vidéo](https://www.youtube.com/watch?v=wg2OKSiHng0&ab_channel=CGKrab) pour decouvrir comment texturer de manière procédurales.

---

# Texturage

1. **Préparation UV :**
    - Sélectionner les arêtes pour créer des découpes et générer une UV Map.
    - Exporter cette UV Map en PNG.

2. **Peinture dans GIMP :**
    - Importer l’UV Map dans GIMP.
    - Créer deux calques :
        - UV en guide.
        - Couleurs pour peindre les zones.
    - Exporter la texture peinte.

3. **Appliquer dans Blender :**
    - Importer la texture comme **Base Color** dans le matériau.

---

# Modèle Personnel – Téléporteur

1. **Création de la base :**
    - Créer un cube.
    - Extruder des faces et appliquer des bevels pour une plateforme.
    - Extruder une face centrale vers le bas.

2. **Effet d’activation :**
    - Créer un cylindre.
    - Supprimer les faces du haut et du bas.
    - Appliquer une texture transparente en réduisant l'alpha
    - Ajouter un modifier Solidify pour donner de l'épaisseur et éviter un problème l'affichage d'un seul coté sur unity. 
