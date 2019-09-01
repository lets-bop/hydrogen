/*
Two priority queues:

A max-heap lo to store the smaller half of the numbers
A min-heap hi to store the larger half of the numbers
The max-heap lo is allowed to store, at worst, one more element more than the min-heap hi.

Adding a number num:
1. Add num to max-heap lo. Since lo received a new element, we must do a balancing step for hi. 
2. Remove the largest element from lo and offer it to hi.
3. The min-heap hi might end holding more elements than the max-heap lo, after the previous operation. 
We fix that by removing the smallest element from hi and offering it to lo.
*/