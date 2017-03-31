# inventory-management-system

## updates/notes:

* added exit button on quick add screen
* window centers on startup
* altered tables to have prices (see database cs file constructor), should probably make it not null and default values to 0 on startup
* quick add now has working confirm/cancel buttons and it adds to database
* quick add games doesn't currently add correctly when multiplatform
* added back buttons with the blue bar on the inventory view page 
* added a scrollbar (some weird issues happening there) but it shows properly when looking at a console's long list of games
* fixed textbox on add game screen
* added in-box to add window, doesn't work with database
* added misc button to add, needs its own png label
* quick add has minor error handling (only whitespace/blank check)

## needs:

* sql table altered for in-box and to allow games to have a platform so that we can add games to their respective platforms for viewing
* more error handling
* get quick add completely working
* get POS at least showing all the inventory for customers
* need to set tabbing order in quick add
