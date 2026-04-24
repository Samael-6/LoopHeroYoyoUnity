# LoopHeroYoyoUnity

# But du Jeu :
Dans ce loop hero le but est de récupéré une épée dans le cimetière qui permet de vaincre la sentinelle en moins de cents actions de déplacements. En cas contraire c'est la défaite car le roi n'a pas pu atteindre son palais à temps pour gérer le royaume.

# Déplacement
Le joueur appuis sur un bouton qui lui permet d'avancer aléatoirement d'une à trois case vers l'avant.

# BP_Lettre_Du_Roi
Elle introduit le joueur et l'informe de sa quête en début de partie

# BP_Roi
Si le joueur n'a pas vaincu la sentinelle, à la première rencontre le roi l'acceuil et lui parle en bref de l'univers avec un ton détaché. Lors de la deuxième rencontre si la sentinelle n'est pas vaincue le roi renvoie le joueur l'affronter. Qu'importe si le joueur est venu avant ou non, s'il a vaincu la sentinelle le dialogue de victoire est déclanché.

# BP_Sentinelle
Si le joueur n'a pas l'épée en passant sur la case alors, un dialogue qui parle de s'équiper se déclanche et il est téléporté dans un mini-jeu où il ne doit pas se faire attrapper. Si il se fait attraper alors il meurt et perd la partie. En cas contraire le joueur vainc la sentinelle et il est téléporté à la case du roi ce qui déclenche le dialogue de victoire.

# BP_Femme_Louche
Lors de la première rencontre elle dialogue avec le joueur lui donnant de l'aide en le téléportant au cimetière où se trouve l'épée. Lors de la deuxième rencontre elle indique qu'elle a déjà aidé.

# BP_Graveyard
Fait apparraître un widget qui s'efface qui signifie au joueur qu'il possède l'épée.

# Exit
Lorsque le joueur atteint la case de sortie, il est téléporté dans la map principal. Malheureusement j'ai aucune idée pour me débarasser du fait que je loop sur le mini jeu lorsque je clique sur next dans l'HUD dialogue.

# Divers
J'ai mis à jour le système de sauvegarde en prenant un peu d'avance sur le prochain rendu. J'espère pouvoir régler mon "bug" avec le mini-jeu et pouvoir test en faisant un executable.

# Mini-Jeu
--> Le but est tout simplement de s'évader du labyrinthe dans lequel rode la sentinelle, en cas contraire le joueur meurs et perd la partie.
--> Le second mini-jeu est un memory, moins le joueur se trompe plus vite il peut revenir dans la map principal et le moins il sera bourré longtemps.