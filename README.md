# RPG-game-Inventory-Tool

# My Take
Inventory/Shop  system of guns was implemented primarily on scriptable There's one base scriptable object called Weapon Data and each has it's own scriptable copy.For the sake of test I have implemented for all guns, but we can easily extend the base class focusing on S.O.L.I.D principles to create new scriptable object scripts for knives and grenades which can have their own properties.
 There are gameEvents and GameEventListeners scriptable objects that takes care of actions whenever some event like clicking of button takes place .Game events are invoked whenever a button is pressed and relevant listeners are notified regarding this.GameEventListeners subscribes to the mentioned gameEvent on enable and whenever that gameEvent takes place they invoke all the listed actions.Then to have userData accessed globally there's one scriptable object for UserData class which gets refreshed whenever scene is started.In the end to put everything on the UI there is UIManager which takes scriptable objects passed by GameEventListeners and populate the UI accordingly.
