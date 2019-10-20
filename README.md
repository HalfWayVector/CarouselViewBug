# CarouselViewBug
Sample application that shows a bug in CarouselView.

## Description
Method pointed by PositionChangedCommand attribute doesn't seem to be triggered on the last carousel item when PeekAreaInsets is not zero. It work as expected when value is zero.
