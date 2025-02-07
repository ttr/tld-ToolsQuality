## Tools Quality
Mod for TLD (The long dark)

This Mod allows You to:
* modify time to perform actions like wood (branches/limbs) and carcass harvesting
* modify time to perfom actions based on tool quality, separate for manufactured tools, primitive tools and hacksaw.
* Manufactured tools, can have time bonus if keept at high quality.


### Mod concept
Issue: In TLD tools quality are ignored and it's pointless to keep them maintained.

* Quality of tool will affect it's efficiency (time to complete task)
* Improvised tools have lower top efficiency but higher bottom one while compared to manufactured ones
* Manufactured tools can have "boost" efficiency above certain threshold
* Manufactured tools get inoperable below certain threshold while crude will work on minimal efficiency (do not get destroyed)
* Add stone tool(s) - it's efficiency is lower than any other tools
* (optional) Struggle tweaks - damage is scaled based on all above.
* Deprecate "QuickerWoodCutting" and add it to this (as base) and perhaps extend functionality to animal harvesting.


Lets say efficiency is arbitrary number from 0 (does not work) to 400, where vanilla manufactured tool is working on 300, improvised is 200. 
Improvised tool at 0% (well 5% if we go with path that they do not get broken) it's efficiency will be 100, while at 100% will be 200.
Manufactured at 0% efficiency is 0, at Y% is 50 (where Y is low threshold / breaking point), at X% is 300 (where X is threshold up to where degradation starts).
If boost is enabled, there is also Z% - if quality is above Z%, tool efficiency can go above 300. Disabling boost will be done by setting it to 100%.
0% > Y% > X% > Z% >= 100%
![graphs](/TQ_graph1.png)

### Issues / shortcommings.
If this mod is enabled for crafting time will be adjusted drastically based on tool condition.
In same time, it also might adjust materials needed - bad tool condition, most likely will cause more materials needed; similary good condition might cause less materials to be used.
This is, because vanilla consume items based on % done and current game-code doesn't easly allow to inject on this function. I actually do reset that value in end of crafting.
More, last 10 minutes need's to be done using no alterations, ortherwise item will not be finished ever. For this, each crafting that have "Work In Progress" item, will be done in at-least two stages.
And cherry on top - UI will not update correctly after returning from crafting - You need to change tool/change bluepring back and forth.

If You do not like any of this, set it off in settings.

