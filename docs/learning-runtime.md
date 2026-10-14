# Learning runtime

The recipe title lesson compares two actual compiled XAML bindings: `x:Bind ViewModel.Title, Mode=OneWay` and `x:Bind ViewModel.Title, Mode=OneTime`. Two TextBlocks are compiled into the page; the selected mode determines which one is visible. Choosing a mode refreshes the compiled bindings using `Bindings.Update()`.

The state bridge reports the active TextBlock's real `Text`, `ActualWidth`, and `ActualHeight`. It never manufactures a rendered value in JavaScript. The repair challenge changes `ViewModel.Title` twice and checks the active TextBlock after each change. The source panel includes both TextBlocks and the switcher implementation.

This distinction matters: the lesson teaches compiled `x:Bind`, not every behavior of runtime-created `Binding` objects. The project export retains both compiled bindings, edits both title sizes, and sets the selected default mode in the page code.

A browser test must demonstrate OneWay propagation, OneTime non-propagation after refresh, failure of the broken challenge, and success after repair before the deploy job can run.
