# NoNewPlayers
Small Unturned plugin that allows your current playerbase to play, but blocks new players.

This plugin can be used to curb attacks against your server, or problematic hackers using vpns and alt accounts.


**Note: This plugin uses the Moderation2 API, and requires <a href="https://moderation.shimmymysherbet.com"/>Moderation2</a> to operate**

This plugin was rapidly thrown together, so some aspects may be refactored.

## Commands:

### **/NNPToggle**

Toggles the NoNewPlayers restrictions.

### **/NNPResetBanFrom**

This plugin works by using Moderation2's player info database, using the first seen field to detect 'new' players. This plugin blocks players whose 'first-seen' is after a certain date. This date defaults to the date you installed the plugin.

Even if a player is blocked from joining the server by this plugin, their player info is still recorded by Moderation2. You can change the 'allow before' date with this command.

This will effectively 'whitelist' any players who tried to join your server before the set time.

This can be a useful tool to curb mass usage of alt accounts/server raids, as a form of 'locking down' the server.

## Config:

### Database
The database settings to the database that Moderation2 is using.

### Enabled
Toggles the functionality of the plugin, also toggled with `/NNPToggle`

### BanFromTicks
Setting used by the plugin to store the 'allow before' date. Use `/NNPResetBanFrom` to set this.

## Translations
Contains 1 entry that allows you to change the message shown to players who are blocked from joining the server.

Default: `Sorry {0}, we're not accepting new players right now` Where `{0}` is the player's Username.

**Note: This plugin uses the Moderation2 API, and requires <a href="https://moderation.shimmymysherbet.com"/>Moderation2</a> to operate**
