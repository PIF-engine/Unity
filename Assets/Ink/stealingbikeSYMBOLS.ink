VAR gender = "female"
VAR topic = "psychology"

* [male]
~ gender = "male"
-> choose_topic

* [female]
-> choose_topic

===choose_topic===
* [psychology]
~ topic= "psychology"
->main0

*[CS]
~ topic = "CS"
->main0

===main0===
{gender == "male": -> male1 | -> female1}

===male1===

Bright.

That’s what described this early Sunday morning, the birds were chirping and singing their usual song. The wind, so fresh, lightly fanned his sun-tanned skin as he biked down the boardwalk.  

$$$

He had wanted to make a quick stop to pick up some dried fruits from the nature store on the corner. Dried fruits always had his blood pumping before presentations and that’s exactly what he needed after having spent the whole previous day practicing for this presentation on: Genie the wild child and cognitive development or Algorithms and data structure.

$$$

{topic == "CS":-> CS1 | ->psychology1}

===CS1===

Binary search
Linked list
Recursive function 
Logarithmic complexity
->male2

===psychology1===

Social isolation 
Language acquisition
Lateralization 
Lenneberg
->male2

===male2===
The words flew around his head like a pestering fly. He shook his head and attempted to clear his mind. 
He hopped off his bike for a single moment and left it on the curb as he made his way into the store. 

$$$

Whistling, he left the store and headed towards his bike only to find that it was not there. Panicked, he thought to himself: how? I hadn’t been away from my bike for over a minute! Who would even steal a bike in this small town? This is the worst possible time for such a thing to happen. Why me?


$$$

Frantically he looked around to see if he could find it but there was nothing in the distance, not a single trace of the thin wheels, as though no bike had ever been ridden on these country roads. While he wouldn’t normally be so frantic about a material object, this bike held sentimental value to him. And what made matters worse was that his notes were left on the bike and he would now have to find an alternative way to get to university on time.  

$$$

What a disaster, he thought.

%%%

2 weeks later


$$$

The aroma of coffee pervaded the air on this cool day. The smell in itself helped wake him up as he wandered around town.  

$$$

He had taken these last couple of weeks to appreciate the slower pace of life and took time to pay attention to details as he walked from place to place. It helped him organize his time better and sort his head. He had almost forgotten about his bike until he saw it tied to the bench in front of his university’s café. The feelings of anger that ruined his day 2 weeks prior had re-emerged. 

$$$

After a second of speculation and doubt, he was positive that it was his bike once he noticed the section on his seat cover that he had personally stitched back together after his young cousin thought it would be funny to poke a pair of keys into. He’d never thought that he’d be so happy to see that tear again.

$$$

By instinct, he was about to hop on his bike and ride home until he realized that he would have to undo the tie/ break the lock. He was so focused on breaking the lock free that he hadn’t noticed the tall blonde angrily running towards his crouched figure. He wasn’t prepared for this confrontation. 


$$$

“What on earth are you doing?!” she yelled at him. He defensively told her that it was his bike and that she had stolen it from him. “Are you out of your mind? I bought this online last week.” She was now accusing him of stealing his own bike, how ironic. She secured the lock again, gave him a stern look and walked away.  

$$$

He was so angry and began pacing around the area trying to think about how he was going to reclaim his property. 

$$$

Then it hit him, how would he be any better if he stole it back? She would be placed in the same situation that he was subjected to 2 weeks ago. He remembered how that event ruined his day and felt a pang of guilt when considering taking his bike back.

$$$

But it was his bike…he glanced back at it and…


->END
===female1===

Bright.

That’s what described this early Sunday morning, the birds were chirping and singing their usual song. The wind, so fresh, lightly fanned her sun-tanned skin as she biked down the boardwalk.  

$$$

She had wanted to make a quick stop to pick up some dried fruits from the nature store on the corner. Dried fruits always had her blood pumping before presentations and that’s exactly what she needed after having spent the whole previous day practicing for this presentation on: Genie the wild child and cognitive development or Algorithms and data structure.

$$$

{topic == "CS":-> CS2 | ->psychology2}

===CS2===

Binary search
Linked list
Recursive function 
Logarithmic complexity
->female2

===psychology2===

Social isolation 
Language acquisition
Lateralization 
Lenneberg
->female2

===female2===
The words flew around her head like a pestering fly. She shook her head and attempted to clear her mind. 
She hopped off her bike for a single moment and left it on the curb as she made her way into the store. 

$$$

Whistling, she left the store and headed towards her bike only to find that it was not there. Panicked, she thought to herself: how? I hadn’t been away from my bike for over a minute! Who would even steal a bike in this small town? This is the worst possible time for such a thing to happen. Why me?

$$$

Frantically she looked around to see if she could find it but there was nothing in the distance, not a single trace of the thin wheels, as though no bike had ever been ridden on these country roads. While she wouldn’t normally be so frantic about a material object, this bike held sentimental value to her. And what made matters worse was that her notes were left on the bike and she would now have to find an alternative way to get to university on time.  


$$$

What a disaster, she thought.

%%%

2 weeks later

$$$

The aroma of coffee pervaded the air on this cool day. The smell in itself helped wake her up as she wandered around town.  

$$$

She had taken these last couple of weeks to appreciate the slower pace of life and took time to pay attention to details as she walked from place to place. It helped her organize her time better and sort her head. She had almost forgotten about her bike until she saw it tied to the bench in front of her university’s café. The feelings of anger that ruined her day 2 weeks prior had re-emerged. 

$$$

After a second of speculation and doubt, she was positive that it was her bike once she noticed the section on her seat cover that she had personally stitched back together after her young cousin thought it would be funny to poke a pair of keys into. She’d never thought that she’d be so happy to see that tear again.

$$$

By instinct, she was about to hop on her bike and ride home until she realized that she would have to undo the tie/ break the lock. She was so focused on breaking the lock free that she hadn’t noticed the tall blonde angrily running towards her crouched figure. She wasn’t prepared for this confrontation. 

$$$

“What on earth are you doing?!” she yelled at her. She defensively told her that it was her bike and that she had stolen it from her. “Are you out of your mind? I bought this online last week.” She was now accusing her of stealing her own bike, how ironic. She secured the lock again, gave her a stern look and walked away.  

$$$

She was so angry and began pacing around the area trying to think about how she was going to reclaim her property. 

$$$

Then it hit her, how would she be any better if she stole it back? She would be placed in the same situation that she was subjected to 2 weeks ago. She remembered how that event ruined her day and felt a pang of guilt when considering taking her bike back.


$$$

But it was her bike…she glanced back at it and…


-> END