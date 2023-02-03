# Installation
1. [Télécharger docker desktop](https://www.docker.com/products/docker-desktop/)
2. Cloner le projet
``git clone https://github.com/shawpoufo/TicketingSystem.git``
3. Se positionner sur le dossier du projet
 `cd TicketingSystem`
 4. Lancer application à l'aide de docker-compose
 `docker-compose up`
 5. Lancer le l'adresse de l'application front dans le navigateur web
 `http://localhost:5005/`
# Adresses des micro-service
 - application front-end : [http://localhost:5005 ](http://localhost:5005/)
 - GateWay : [http://localhost:5000 ](http://localhost:5000/)
 - CustomIdentity : [http://localhost:5001 ](http://localhost:5001/)
 - Ticket : [http://localhost:5002](http://localhost:5002/)
 - Organisation : [http://localhost:5003](http://localhost:5003/)
 - Conversation : [http://localhost:5004](http://localhost:5004/)
# Captures d'écran
## Page d'acceuil
![Home](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/home.png)
## Page de connection
![Login](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/login.png)
## Page d'enregistrement
![SignUp](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/signup.png)
## Page de list des organismes
Un organisme est une entité qui rassemble tous vos clients de votre produit et les agents qui vont résoudre leur problème.
![organisation](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/organisation.png)
## Formulaire pour ajouter un organisme
![organisation](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/organisationForm.png)
## Tableau de bord de l'admin
À partir de ce tableau de bord l'admin peut suivre l'état d'avancement des problèmes postuler par les clients en temps réel, chaque ticket est un problème qui doit être résolue par un agent, un ticket dispose de trois états.
![adminDashboard](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/adminDashboard.png)
### Attribuer un ticket à un agent
Afin de attribuer un ticket il va faloir avoire un agent sinon ajouter le dans l'onglet des agents
![assignTickets](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/assignTickets.png)
## Onglet des client
La page des clients affiche les clients d'un organisme choisi ainsi que l'état de leur présence (online/offline) en temps-réel
![clientsList](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/clientsList.png)
## Tableau de bord du client
à travers cette page le client peut :
- Remplire un nouveau ticket
- Consulter l'état d'anvancement des ticket
- Communiquer en temps-réel (chat) avec l'agent
*NOTE : l'agent dispose d'une interface similaire*
![clientDashboard](https://github.com/shawpoufo/TicketingSystem/ProjectImgs/clientDashboard.png)




