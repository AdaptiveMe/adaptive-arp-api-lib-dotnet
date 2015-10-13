/**
--| ADAPTIVE RUNTIME PLATFORM |----------------------------------------------------------------------------------------

(C) Copyright 2013-2015 Carlos Lozano Diez t/a Adaptive.me <http://adaptive.me>.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the
License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 . Unless required by appli-
-cable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS,  WITHOUT
WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the  License  for the specific language governing
permissions and limitations under the License.

Original author:

    * Carlos Lozano Diez
            <http://github.com/carloslozano>
            <http://twitter.com/adaptivecoder>
            <mailto:carlos@adaptive.me>

Contributors:

    * Ferran Vila Conesa
             <http://github.com/fnva>
             <http://twitter.com/ferran_vila>
             <mailto:ferran.vila.conesa@gmail.com>

    * See source code files for contributors.

Release:

    * @version v2.2.15

-------------------------------------------| aut inveniam viam aut faciam |--------------------------------------------
*/

using System;

namespace Adaptive.Arp.Api
{

     /**
        Interface for Managing the Lifecycle listeners

        @author Carlos Lozano Diez
        @since v2.0
        @version 1.0
     */
     public interface ILifecycleListener : IBaseListener
     {

          /**
             No data received - error condition, not authorized or hardware not available.

             @param error Type of error encountered during reading.
             @since v2.0
          */
          void OnError(ILifecycleListenerError error);

          /**
             Called when lifecycle changes somehow.

             @param lifecycle Lifecycle element
             @since v2.0
          */
          void OnResult(Lifecycle lifecycle);

          /**
             Data received with warning

             @param lifecycle Lifecycle element
             @param warning   Type of warning encountered during reading.
             @since v2.0
          */
          void OnWarning(Lifecycle lifecycle, ILifecycleListenerWarning warning);

     }
}

/**
------------------------------------| Engineered with ♥ in Barcelona, Catalonia |--------------------------------------
*/
