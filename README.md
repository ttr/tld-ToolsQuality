## Tools Quality
Proposed mod for TLD (The long dark)

### Design concept
Issue: In TLD tools quality are ignored and it's pointless to keep them maintained.

* Quality of tool will affect it's efficiency (time to complete task)
* Improvised tools have lower top efficiency but higher bottom one while compared to manufactured ones
* Manufactured tools can have "boost" efficiency above certain threshold
* Manufactured tools get inoperable below certain threshold while crude will work on minimal efficiency (do not get destroyed)
* Add stone tool(s) - it's efficiency is lower than any other tools
* (optional) Struggle tweaks - damage is scaled based on all above.
* Deprecate "QuickerWoodCutting" and add it to this (as base) and perhaps extend functionality to animal harvesting.

### Design details
Lets say efficiency is arbitrary number from 0 (does not work) to 400, where vanilla manufactured tool is working on 300, improvised is 200. 
Improvised tool at 0% (well 5% if we go with path that they do not get broken) it's efficiency will be 100, while at 100% will be 200.
Manufactured at 0% efficiency is 0, at Y% is 50 (where Y is low threshold / breaking point), at X% is 300 (where X is threshold up to where degradation starts).
If boost is enabled, there is also Z% - if quality is above Z%, tool efficiency can go above 300. Disabling boost will be done by setting it to 100%.
0% > Y% > X% > Z% >= 100%

![graphs](Quality tools - page 1.png)

#### Stone tools
(CC @TheDev for model permission)
I would simplify Stone tools t single tool - "sharp stone" and define it as hatchet.
This way it could be used for harvesting and wood chopping.
Creating two tools (knife and hatchet) is bit pointless. Knife would be mentioned sharp stone while stone hatchet would be stick + sharp stone + tiding (line, gut, cloth).
Because stick is very weak this would be very low condition item and in end would be destroyed anyway.

Single item idea IMO works better:
* You can carve meet and skin with it - for simplicity we will ignore fact that it would damage all resulting items and just make it painfully long.
* You can use to cut those small trees (saplings?) - it will be more of "cutting them with blunt knife" than hacking so extend some time
* branches and bushes should be more less same as they are very thin... perhaps just make them same time as no tool
* limbs will take time (you are bashing rock into it) and with high possibility of breaking - or very high degradation, or (preferred) RNG test to destroy this tool on use.

Proposed values:
Animal harvesting: 3-4x
Limb chopping: 4-5x
Branch/Bush chopping: 1.5-2x
Small trees: no change (for now)


