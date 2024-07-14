# Wise Feline Utility AI Lite for Unity

[Documentation](https://www.nooparmygames.com/WF-UtilityAI-Unity/) | [AssetStore](https://assetstore.unity.com/packages/slug/235906) | [Discord](https://discord.gg/FA8R7APZWR) | [twitter/x](https://twitter.com/nooparmy)

This project is a free Utility Ai plugin for Unity with a paid extension.

We at [NoOpArmy](https://nooparmygames.com) made this plugin along side influence maps for both Unity and Unreal and have made a few additional packages too.

A version of this with a life simulation demo is available on the [AssetStore](https://assetstore.unity.com/packages/slug/249840)

The pro version with action priorities and multiple selection algorithms and influence maps smart objects and AI Tags with a more advanced demo can be bought [here](https://assetstore.unity.com/packages/slug/235906).

# Features

Wise Feline is a utility AI system which allows you to make immersive AI with ease. It works pretty well for agents with lots of actions and complex situations and has a great visual debugger.

- Do you want to make AI which acts more naturally and more believable than AIs of most games?
- Do you want your AI to react to everything in the environment and don't have a rigid structure?
- Do you want AI which can be easily procedurally modified at runtime by you or by your players as user generated content?
- Do you want your AI to react cleverly to unexpected behavior and in general does things which surprises and delightes your users?
- Do you want to easily change the design of your AI during production and add and remove actions without getting worried on how to understand complex trees or state machines?

If the answer to some of these questions is yes for you, Wise Feline is made for your project.

Do you want to know what Wise Feline can do for your game genre or what it adds to games in general? [Click here](https://www.nooparmygames.com/WF-UtilityAI-Unity/articles/cookbooks/game-genres.html)!

Wise Feline allows you to create complex immersive agents which can act correctly in complex situations which even the designers did not think of. Big games including the sims, guild wars 2 and many others use a form of utility AI.
With Wise Feline you don't need to create huge and hard to follow state machines and behavior trees and instead you can give all of your actions a scoring mechanism which tells the system how important each action is at a moment in time. Because all actions are considered all the time, your AI will never be out of good options and it chooses the best action for the situation in a pretty intuitive way. You can group your actions based on priorities and use different selection algorithms for finding the best action. More details can be found in the technical details below.
Your designers no longer have to add specific transitions in state machines or conditions and nodes in behavior trees. By tweaking importance and utility of actions relative to each other in a utility AI system, they can easily change the behavior of the agents in an intuitive way and check why something behaves the way it does in the visual debugger.
Because all actions are considered all the time and you can add as many actions as you want with as many scoring conditions as you want, Wise Feline is perfect for games with emergent gameplay, open world games, virtual worlds, metaverses and MMOs but it can be used not only for agents in almost all genres but you can even use it to drive things like lighting, cameras, VFX and ...
State Machines and behavior trees still can be the tool of choice if you want very specific strict behavior which should be scripted exactly but if you want your agents to behave and think like humans or always choose something from their entire set of actions instead of only being able to go to specific states from a single state, Utility AI is your best bet.

Utility AI works based on actions and their importance score at each tick and this means you can change your agent's behavior based on the environment very easily. you can make your character more brave by having score considerations which give a higher score if friendly forces are around and ... Not that it is impossible to achieve the same thing with other approaches but it is very hard. With utility AI agents can have awesome environmental awareness and go persoanl and team transformations which feel very realistic from the player's viewpoint.
Since actions and utilities is the way that us human think and evaluate situations with, designers can map human experiences much easier to the game agents. Why think of selector nodes and decorator nodes and state transitions, if you can think about in what situations is this action important and how much?

## Technical features

- Built-in actions and considerations for easy prototyping: The package contains a growing list of built-in actions and considerations which are pretty generic and can be used for prototyping and even in real games.
- Life simulation sample with interesting cartoonish artwork which helps you understand how to use the system.
- Easy to learn: There are only a few concepts to learn, mainly actions, considerations and agents. Each agent has a set of actions to choose from and each action is scored by scoring a set of considerations which show how important the action is at the moment.
- Easy programming interface: You only need to derive from ActionBase and ConsiderationBase to create new actions and considerations and then drive your agent inside your action code. You only have to attach a single new component to your AI agents to be driven by utility AI.
- Visual Debugger and design tool: There is a window to design your AI by setting consideration curves and choosing how much a consideration affects an action for a specific agent and also to debug action scores at runtime. You can examine what score exactly each action got at each frame and how to modify the curves to get the result you want. Your agent doesn't set enemies on fire as much as you want? make the curve for the Love Of Fire consideration more steep!
- Action priorities and interruptability Each action can optionally have a priority and can declare itself uninterruptable. Actions with higher priorities and lower scores are preferred to actions with lower priorities. Priorities are only available in the ultimate version.
- Multiple Action Selection Modes Each brain component can choose the action to execute using multiple selection algorithms from the highest score to weighted random and random from top N both with/without considering priorities. Selection modes other than the highest score are only available in the ultimate version.
- Action based targetting: Each action which needs a target is scored once per target and the best target is chosen. The targetting system is flexible and allows you to find the targets for each action in any way you want. Do you want to use a manager class which knows all the targets? a sphere cast? some custom made system? it is just a callback in Wise Feline and we won't limit you. There is only an upper limit of number of targets per action which you can use so the system doesn't spend too much time looking at too many objects.
- Influence maps This package contains an influence maps module which allows you to do spatial queries like where in the map doesn't contain enemies but lots of trees are there for cutting? Where can I throw my grenade to apply the most damage? Where are the paths cargos usually use so I can ambush them?
- BlackBoards: Both versions of the package contain a blackboards module which help you share information between different parts of your AI and make reusable actions and considerations.
- Data Recorder allows you to record data per GameObject per frame as a tree of texts and supports ritch text as well. You can easily integrate it to any script which benefits to know what happend over time. We integrated it to our Utility AI brain to record all action and consideration scores over time.
- Smart Objects allow you to put the desired behavior in the object and then the agent only asks which objects can fulfil a need and the objects advertise themselves to it. Then the agent uses one of them to fulfil the task it wanted to perform.
- Extra modules: The ultimate version of the package contains a growing list of modules which currently contains Influence maps, smart objects and an AI Tag system which allows you to tag objects and query for objects in a sphere and check their tags pretty fast. Do you want to find all foods around an NPC so he/she can eat one of them? Just search for objects tagged food around its position and find them without doing raycasts and using a fast octree. Add tags like enemy, leader or target to objects at runtime so other AIs can dynamically do something to it. The usecases are endless and unlike unity tags, these tags are not only queriable using spatial queries but also don't have limits on their count.
- High Performance and optimizable: The asset doesn't use heavy APIs, uses burst for influence maps (optional) and doesn't use lots of memory, also since you can choose how often different AI systems from finding targets to calculating scores run per agent, you can optimize the system for your game. Do you want far away agents to run less often? Do you want them to change their targets less often? just change two values in the Brain component based on their distance to the player and that's it.
- Full source code: We don't know all of your project needs so the asset ships with all source code including the editor code and UI toolkit based UI.
- Easily extensible: The asset doesn't use any super complex useless abstractions. It uses scriptable objects for storage and everything can easily be added to and even examined by editor scripts outside the systems. None of the classes are big and everything is documented fairly well and systems are designed in a way that makes it easier to change a class's internals without the need to change the classes using it.
- Extensive [Documentation](https://www.nooparmygames.com/WF-UtilityAI-Unity/): There is extensive API documentation and a manual which describes how to code for the system with a complete example scene which we will add to over time.

## Videos

First intro https://youtu.be/46fl86r0F0o
Tutorial https://youtu.be/MOigmDqnIKk
Lifesim lite https://youtu.be/iw-gF2154QI
Immersive https://youtu.be/9WJ-IcETh5M
200 agents https://youtu.be/gYlWjfvru1Q

# License

[Unity AssetStore licensing agreement](https://unity.com/legal/as-terms)