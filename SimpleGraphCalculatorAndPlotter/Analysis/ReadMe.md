# Request
[Software Plotter](Task_Software_Plotter.pdf)

---

# Requirements

A user wants to modify (add) the parameters of the trigonometric functions sin, cos and sinc.
- sin(x): a * sin(b * (x - c)) + d 
- cos(x): a * cos(b * (x - c)) + d
- sinc(x) = si(pi * x) = sin(pi * x) / x

He can select one of them and is shown a 2d visualization of the unmodified function.
- combobox with entries (sin, cos, sinc)
- radio buttons / button bar?

When the user modifies the parameters a second visualization is shown reflecting the changes that the parameters introduced.
- when to trigger redraw? (lost focus, button, parameter change)
- color / style of default function and modified function

The visualization is plotted in a 2d coordinate system. The ranges for the x- and y-axis can be adjusted by the user.
- coordinate system style
- redraw on lost focus or range change?
- range adjustment controls?
  - 4 text boxes for minX, minY, maxX, maxY (position of the text boxes)

When the application is closed the last parameters should be saved and reused with the next application start.
- always active?
- default/Start Values

The user has the possibility to save the plotted functions in a vector format.
- button text?
- save file dialog or path text box?
- which format?
- where is the button? 
- default file name