====== Techniques impl�ment�es =================================

- Colonisation de l'espace
- Mod�le de Borchert Honda
- Agr�gation des nouvelles branches avec pond�ration
- Calcul de la largeur des branches
- G�n�ration proc�durale du maillage � partir du squelette

====== Instructions d'utilisation ==============================

Pour des raisons de simplicit� nous avons pr�par� des objets
(GameObjects) dans la sc�ne qui servent � afficher les meshs 
g�n�r�s par l'outil de g�n�ration d'arbre.

Pour tester la g�n�ration d'un arbre :
- Ouvrir le projet Unity (version 5.4.3f1 de pr�f�rence)
- Dans l'explorateur d'assets, ouvrir le dossier "DataGen"
- S�lectionner, au choix, l'un des fichiers "tree_data_XX"
- Dans l'inspecteur � droite, modifier �ventuellement quelques
param�tres puis cliquer sur "Generate tree"

Cela va alors g�n�rer un nouveau mesh et l'exporter dans le 
dossier "Meshes". Des changements devraient apparaitre dans 
la sc�ne.

Astuce : Pour plus de clart�, il est possible de d�sactiver les
objets ind�sirables de la sc�ne en les s�lectionnant, et, dans
l'inspecteur, d�cocher la case situ�e � gauche du nom du 
GameObject.

====== Echantillons ============================================

Quelques screens sont �galements pr�sentes dans le dossier
"output_sample" (en dehors du projet Unity).