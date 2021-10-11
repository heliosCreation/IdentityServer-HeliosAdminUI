# IdentityServer4-HeliosAdminUI

This application is a "ready to go" project aiming to simplify your experience with the - amazing - IdentityServer of Dominick Baier and Brock Allen.
There are two main points that differs from the original templates already kindly available and that we'll discuss here.<br/> The first one is to offer persitency to your configuration through database storage. Instead of only writting your configuration in the good old "Config.cs" you will also have the possibility to manage it in a SQL-server database instance through a UI.<br/> A User store based on Identity Framework is also provided with basical authentication services, aka *Registration*, *Sign in*, *Email Confirmation*, and *Password Reset*. No mail service here though, so you'll have to implement it yourself. <br/>
The second main topic here is the UI. API scopes, Identity Resources, Clients, Users, and Roles are all manageable through a built-in interface, secured with *Identity Framework* and documented with the definitions available on the [Official Documentation](https://identityserver4.readthedocs.io/en/latest/).

Interested? Let's dig right in. 
## Installation

To begin with, you'll have to clone this project.<br/>
Choose your location of choice on your local machine, and type:

```bash
git clone https://github.com/heliosCreation/IdentityServer-HeliosAdminUI.git
```
In order to be able to push your own work to your future repo, modify the origin:
```bash
git remote set-url origin https://github.com/YOU/YOUR_REPO
```

Once the project is install, we'll have to get those databases working.<br/>
So let's open the solution and start the exploration. 

## Databases Setup
<h4>1 - Connection Strings</h4>
In the <i>appSettings.json</i> you'll find the connection strings to setup the informations used to create your databases. <br/>
<img width="521" alt="ConnectionStrings" src="https://user-images.githubusercontent.com/71494857/136692217-3b5c366a-568e-4d1a-bafd-660636a05205.PNG">
Change the server location and database name as per you need.

Once you're good with that, we're going to create your databases.
<h4>2 - Run the updates. </h4>
Since the migrations files are already in the project, all you have to do in to run the updates.
Open your package manager and run those commands:

```bash
Update-database -c ApplicationDbContext 
```

```bash
Update-database -c PersistedGrantDbContext 
```

```bash
Update-database -c ConfigurationDbContext
```

```bash
Update-database -c CustomConfigurationDbContext 
```

And here we go, just like that our stores are ready to be used. 

<h4>3 - Let's plant some seeds :seedling: </h4> 
The application is design to enable a default basic seeding of Configuration, Users and Roles.<br/>
In order to use it, all you have to do is to launch your project with specific parameters. If you dig a little bit in the "Program.cs", you'll see those three lines of code:
<img width="210" alt="Seeds" src="https://user-images.githubusercontent.com/71494857/136692986-cc196b56-24b1-4d46-8124-9601addd2f38.PNG">

Pretty clear in terms of arguments, right? <br/>
So Right click on your project, go to Properties > Debug and let's start with the Roles:
<img width="449" alt="Args" src="https://user-images.githubusercontent.com/71494857/136693242-93367d61-889b-468a-9029-b19eb5abdc62.PNG">


Start the project, and you should see a terminal with those informations written:


<img width="174" alt="SeedRole" src="https://user-images.githubusercontent.com/71494857/136693278-de2e9528-578f-42e3-a5be-eab17cb4d85a.PNG">

Repeat the operation with the the <i>seedUsers</i> and <i>seedConfig</i>, the terminal should open again with validations messages.<br/>

<h4> 4 - Additional notes about the seeds behaviour </h4>
<ul>
  <li> The role seed, will insert one role in the DB. Named <i>IsAdmin</i>. Said role will be used to access the Admin feature of the server. Change the name as per your need, but    remember to also take a look at the Authorization method of the controllers to replace it as well.
  </li>
  <li> The user seed will insert three default users in the database. Alice & Bob with password <i>Pass123$</i>, and admin with password <i>Pwd12345!</i>. Remember to modify this password in the future. 
  </li>
  <li>
    The configurational seed will use the information found in the config.cs to produce the first set of data. Customize it per your need !
  </li>
</ul>

## Discovery of the UI
Now that the preparation is done. I'm gonna walk you through the interface and the features you can access.<br/> 
First we'll have to login with the admin account. If the login is successful, in the upper right corner of the navigation bar you should see a new dropdown: 
<img width="954" alt="HomeDropdown" src="https://user-images.githubusercontent.com/71494857/136767072-a12c3c02-e393-4a1a-866e-cb9c5574134c.PNG">


We are first going to access the home page: 
![HomePage](https://user-images.githubusercontent.com/71494857/136753753-40b0e18e-3d85-431d-80a8-f1696142bd5a.png)

I think the page itself is pretty self-explanatory. The four main management themes of the app are here. Let's begin with the Api Scopes management now, shall we? 

<h4>1 - Api Scopes </h4>
All of the sections presented above, when clicked, will take you to a page with two choices. Choice 1, show me my resources. Choice 2, let me create a new one.
<img width="958" alt="ApiScopesHome" src="https://user-images.githubusercontent.com/71494857/136754133-d85a6f22-3cb3-4572-92cc-657a1e3f67a9.PNG">
<br/>
<h5>A - The List </h5>
Would you choose to access the List, you will be taken to a page letting you see you resources along with the major fields defining it. <br/>
Three options are also given here: Create, Update and Delete. Following the basics of a CRUD implementation.
<img width="913" alt="ApiScopeListed" src="https://user-images.githubusercontent.com/71494857/136755653-93b4085d-d4e7-4546-a163-227adffc4898.PNG">

<h5>B - The Creation </h5>
When choosing to create a new resource, you will be taken to a form letting you specifies the configuration you wish for you resource. <br/>
Along with it, as displayed in the image below, some usefull information about the fields can be accessed by hovering the "(i)" icons following the labels: <br/>
<img width="751" alt="ApiScopeCreate" src="https://user-images.githubusercontent.com/71494857/136756378-db94aa42-4e57-4d8e-989d-b023cd49f030.PNG">

Upon valid creation, you will be prompted with a validation message:
<img width="627" alt="ApiScopeSuccess" src="https://user-images.githubusercontent.com/71494857/136757410-8655b64f-d0c0-4984-8035-ca9e7ea5619a.PNG">

<h5>C - The Update </h5>
On the displayed list of your resource, if you choose to click on the green pen icons in the "Actions" column, you will be taken to a view similar to the one displayed above. The only difference being that the fields will be pre-populated with your past choice. Modify them at will and validate your choice by clicking on the "Update" button. 
Your will, once again, be prompted with a validation message. 

<h5>D - The Deletion </h5>
On the displayed list of your resource, if you choose to click on the red bin icons in the "Actions" column, you will be taken to the view below, asking you to validate your wish to delete this resource a second time: 
<img width="958" alt="ApiScopeDelete" src="https://user-images.githubusercontent.com/71494857/136759270-13b4998d-bf90-4e8d-b694-2b59ab461989.PNG">
 Once done, and as always, a validation message will be prompted to you.<br/>
 
 
<h4>2 - Identity Resource </h4> 
The management of the Identity Resources mostly follow the same flow. Only difference being in the create method. In order to create the claim for your Identity resource, you are given the ability to create and/or remove tags representing the desired claims. To add one, type in the corresponding bar and press "Enter". To remove it, click on little arrow being part of the tag. 
 <img width="924" alt="IdentityResourceCreate" src="https://user-images.githubusercontent.com/71494857/136760872-afcb8988-ad0e-4ed0-a28f-4948d185485a.PNG">
  
<h4>3 - Clients </h4> 
The flow is once more mostly similar, the difference being again in the create method.<br/>
The form is splitted in three main sections. The first one, being, the "Basic" one lets you define your Id, Name and Secret for this Client. As written in the picture bellow, take note of the Secret you will wish to define, as it won't be available anywhere else later.  
<img width="762" alt="ClientCreate" src="https://user-images.githubusercontent.com/71494857/136762879-a80529f1-e942-4d9d-b961-a8302021b478.PNG">

The second section lets you define the URIs used by the client:
<img width="722" alt="ClientCreateUri" src="https://user-images.githubusercontent.com/71494857/136764134-fa9fe631-f856-48ce-9733-0bbe6227391e.PNG">

The third and final section lets you define the Grants and Scopes of your Client.<br/>
The grant types correspond to the default one provided by the IdentityServer Documentation. The clickable Scopes are also based on the default ones of the documentation.<br/>
Finally, for a more customizable approach, you can create your own custom scopes. 
<img width="736" alt="ClientCreateGrantAndScope" src="https://user-images.githubusercontent.com/71494857/136764803-be05a04c-c5c0-400a-9ac1-774875cc640e.PNG">


<h4>4 - Users & Roles </h4>
We are Lastly going to discuss the about how to manage your Roles and Users on the server. <br/>
From the Admin home page, if you decide to click on the last section, you will taken to a menu offering you two choices: 
<img width="960" alt="UsersAndRoles" src="https://user-images.githubusercontent.com/71494857/136765470-bd4711fb-d5c1-4325-975a-d7f0791bf6cd.PNG">

The User section will give you the capacities to create new user without the need of a proper flow following the Register method. You will also have the ability to add your newly created user to the roles you built on your server. It goes without saying that you will be able to update and delete those users as you wish. <br/>
Below, a caption of the User creation form:
<img width="678" alt="UserCreate" src="https://user-images.githubusercontent.com/71494857/136766093-54c04953-f349-46ef-9bde-bf306428fb52.PNG">

And finally, the Role section. Three possibilities are also given to you here. Creating new roles, Listing them, and deleting them.<br/>
The newly created Roles, will be automatically added to the list of choices you can access upon the creation of a new user. 

## Final Thought
If you went down as far a this line, I would like to thank you for your attention. <br/> This project represents hours of work and head scratching. I know it's not perfect and there are still a good amount of work to be done, but I hope it might be usefull to some of you. 

Enjoy and keep coding !  
## License
[MIT](https://choosealicense.com/licenses/mit/)
 
