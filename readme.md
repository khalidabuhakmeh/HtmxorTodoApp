# HtmxorTodoApp

This is a reimplementation Todo application but now is an Htmx-Powered Blazor application. I'm probably holding a few things wrong, so don't
use this repository as the pinnacle of this approach. 

Frankly, my code is probably two-steps up from what a chimpanzee could do. 🐒

That said, here are some thoughts I had during this sample creation:

1. I like the idea of centralizing Htmx configuration in the `Program.cs` 👍
2. `_Imports.cshtml` is a pain in the butt. It might make more sense to collapse more into fewer namespaces.
   - NOTED. One import should suffice really.

3. I really like the idea of `HtmxFragment` but I'm not sure I agree with the idea that it's the core element. I'd prefer it be an invisible server-side wrapper.

   - Fragments are only needed if you want to render out only parts of a component.

4. I'm not sure I like doing everything in the `OnInitializedAsync` method for every request. (probably holding it wrong)

   - Agreed. My approach is to use event handlers and move logic there. Much more close to how Blazor works.

5. I could probably break down things more into components.

6. Blazor feels like it was built to abstract about the HTTPness of the web, and at times feels at odds with Htmx.

   - Htmxor makes HTTP stuff available via the HtmxContext, either through Context property on ConditionalComponentBase, or via event args passed to the hx event handlers.
  
Feel free to review and point out my silly mistakes. I'm sure there are many.

Cheers, 

Khalid