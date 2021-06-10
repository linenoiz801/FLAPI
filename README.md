# FLAPI

This project will be to build an API to build a database of lore in the Fallout universe. This 
will be used by anyone interested in exploring the history of the game in more detail. The Vault 
Dwellers team are all big fans of the Fallout franchise and believe a publicly accessible database 
will be of great benefit to all mankind and a Super Mutant or two.

[Trello board](https://trello.com/b/p4m8AqLS/vault-dwellers-flapi-api-assignment)
[Database Diagram]( https://dbdiagram.io/d/609b274eb29a09603d14766f )

# LOCATIONS
The user can pull up information related to a specific Location within the game world. A Location will return the Name of the location, the Country and Metropolitan Area that it can be found in, the Game it can be found in, and any historical information available about the Location. Historical and Game data will be returned as a hyperlink to the appropriate API endpoint.

A user will have the ability to Add location information to the database if it is not already available, or Update information if it is. A User will also be able to Delete location information.
## Locations Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Locations in the database
GetById - Get a single Location object 
GetByGame - Get all Location objects with a matching GameId
Put - Update Name, Country, Metro on a specific Location
Delete - Remove a Location from the database
PostCharacter - Create a single entry in characters_locations to link a character record to a location record

# VAULTS
The user can pull up information related to a specific Vault within the game world. A Vault will return the Name of the Vault, the Vault Number, the Location that it can be found in. Location data will be returned as a hyperlink to the appropriate API endpoint.

A user will have the ability to Add Vault information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Vault information.

## Vaults Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Vaults in the database
GetById - Get a single Vault object 
GetByGame - Get all Vault objects with a matching GameId
Put - Update Name, Vault Number of a specific Vault object 
Delete - Remove a Vault from the database
PostCharacter - Create a single entry in characters_vaults to link a character record to a vault record

# CHARACTERS
The user can pull up information related to a specific Character within the game world. A Character will return the Name, Age, Affiliation, IsNPC, IsHostile, Species, Game, and History. Species, Game, and History data will be returned as a hyperlink to the appropriate API endpoint.

A user will have the ability to Add Character information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Character information.

## Characters Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Characters in the database
GetById - Get a single Character object 
GetByGame - Get all Character objects with a matching GameId
Put - Update Name, Age, Affiliation, IsNPC, and IsHostile  
Delete - Remove a Character from the database
PostLocation - Create a single entry in characters_locations to link a character record to a location record
PostVaults - Create a single entry in characters_vaults to link a character record to a vault record

# HISTORY
The user can pull up information related to historical events within the game world. A History object will return the Event Name, Event Date, Description, and Game that it can be found in. Game data will be returned as a hyperlink to the appropriate API endpoint.

A user will have the ability to Add History information to the database if it is not already available, or Update information if it is. A User will also be able to Delete History information.

## History Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all History objects in the database
GetById - Get a single History object 
GetByGame - Get all History objects with a matching GameId
Put - Update Event Name, Event Date,  and Description
Delete - Remove a History object from the database

# GAMES
The user can pull up information related to a game within the Fallout franchise. A Game object will return the Game Name, Release Date, and the Description.

A user will have the ability to Add Game information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Game information.

## Games Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Game objects in the database
GetById - Get a single Game object
Put - Update Game Name, Release Date, and the Description
Delete - Remove a Game object from the database
PostSpecies - Create a single entry in species_games to link a species record to a game record

# SPECIES
The user can pull up information related to a specific Species within the game world. A Species will return the Name of the species, the weaknesses & strengths associated with the species, and any historical information available about the Species. Historical data will be returned as a hyperlink to the appropriate API endpoint.

A user will have the ability to Add Species information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Species information.

## Species Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Species in the database
GetById - Get a single Species object 
Put - Update Name, Weaknesses, and Strengths on a specific Species
Delete - Remove a Species from the database
PostGame - Create a single entry in species_games to link a game record to a species record

# WEAPONS
The user can pull up information related to a specific Weapon within the game world. A Weapon will return the Name of the weapon, the Description and Ammo Type of the Weapon, the Type of Weapon, how much base damage the weapon will afflict upon an opponent, the Game it can be found in, and any historical information available about the Weapon. Historical and Game data will be returned as a hyperlink to the appropriate API endpoint. 

A user will have the ability to Add Weapon information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Weapon information.

## Weapons Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Weapons in the database
GetById - Get a single Weapon object 
GetByGame - Get all Weapon objects with a matching GameId
Put - Update Name, Description, Ammo Type, Weapon Type, and Base Damage on a specific Weapon
Delete - Remove a Weapon from the database

# PERKS
The user can pull up information related to specific Perks within the game world. A Perk will return the Name of the Perk, the Prerequisite to obtain the Perk, the Description of what the Perk does, and the Game it can be found in. Game data will be returned as a hyperlink to the appropriate API endpoint. 

A user will have the ability to Add Perk information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Perk information.

## Perks Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Perks in the database
GetById - Get a single Perk object 
GetByGame - Get all Perk objects with a matching GameId
Put - Update Name, Description, Prerequisite, and Game.
Delete - Remove a Perk from the database

# ARMOR
The user can pull up information related to a specific Armor within the game world. An Armor object will return the Name of the Armor, the Description, Armor Class, how much base defense the Armor will give a player, the Game it can be found in, and any historical information available about the Armor. Historical and Game data will be returned as a hyperlink to the appropriate API endpoint. 

A user will have the ability to Add Armor information to the database if it is not already available, or Update information if it is. A User will also be able to Delete Armor information.

## Armor Endpoints
Post - Create a new object in the database (foreign key Ids must be supplied in V1)
GetAll - Get all Armor in the database
GetById - Get a single Armor object 
GetByGame - Get all Armor objects with a matching GameId
Put - Update Name, Description, Armor Class, and Base Defense for each Armor.
Delete - Remove an Armor from the database

