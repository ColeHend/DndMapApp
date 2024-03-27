# dnd5-srd

Dungeons & Dragons (5th edition) System Reference Document in node module form, as JSON.

Fork of a [project](https://github.com/adrpadua/5e-database) by [adrpadua](https://github.com/adrpadua).

  # Documentation

## How to use?

As a simple example, lets display how many hit points an Aboleth has.
There are two ways to access the data about monsters:

### Approach 1:

```javascript
const monsters = require('dnd5-srd/monsters');
const aboleth = monsters.find(monster => monster.name === 'Aboleth');
console.log(aboleth.hit_points);
```

### Approach 2:

```javascript
const dnd = require('dnd5-srd');
const monsters = dnd.data.monsters;
const aboleth = monsters.find(monster => monster.name === 'Aboleth');
console.log(aboleth.hit_points);
```

## Reference

Currently there's no documentation for how the data looks like. You'll have to explore the JSON files to figure that out.
The following data types are available:
  
*  `abilityScores`
*  `classes`
*  `conditions`
*  `damageTypes`
*  `equipment`
*  `equipmentCategories`
*  `features`
*  `languages`
*  `levels`
*  `magicSchools`
*  `monsters`
*  `proficiencies`
*  `races`
*  `skills`
*  `spellcasting`
*  `spells`
*  `startingEquipment`
*  `subclasses`
*  `subraces`
*  `traits`
*  `weaponProperties`
