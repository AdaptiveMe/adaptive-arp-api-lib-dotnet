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

    * @version v2.2.12

-------------------------------------------| aut inveniam viam aut faciam |--------------------------------------------
*/

using System;

namespace Adaptive.Arp.Api
{

     /**
        Interface for Managing the File result operations

        @author Carlos Lozano Diez
        @since v2.0
        @version 1.0
     */
     public interface IFileListResultCallback : IBaseCallback
     {

          /**
             On error result of a file operation.

             @param error Error processing the request.
             @since v2.0
          */
          void OnError(IFileListResultCallbackError error);

          /**
             On correct result of a file operation.

             @param files Array of resulting files/folders.
             @since v2.0
          */
          void OnResult(FileDescriptor[] files);

          /**
             On partial result of a file operation, containing a warning.

             @param files   Array of resulting files/folders.
             @param warning Warning condition encountered.
             @since v2.0
          */
          void OnWarning(FileDescriptor[] files, IFileListResultCallbackWarning warning);

     }
}

/**
------------------------------------| Engineered with ♥ in Barcelona, Catalonia |--------------------------------------
*/
