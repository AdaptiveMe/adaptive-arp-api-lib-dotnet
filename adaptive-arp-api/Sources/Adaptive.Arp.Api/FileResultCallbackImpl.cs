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

    * @version v2.2.9

-------------------------------------------| aut inveniam viam aut faciam |--------------------------------------------
*/

using System;
using Adaptive.Arp.Util;

namespace Adaptive.Arp.Api
{

     /**
        Interface for Managing the File operations callback
        Auto-generated implementation of IFileResultCallback specification.
     */
     public class FileResultCallbackImpl : BaseCallbackImpl, IFileResultCallback
     {

          /**
             Constructor with callback id.

          @param id  The id of the callback.
          */
          public FileResultCallbackImpl(long id) : base(id)
          {
          }

          /**
             On error result of a file operation.

             @param error Error processing the request.
             @since v2.0
          */
          public void OnError(IFileResultCallbackError error)
          {
               AppRegistryBridge.GetInstance().GetPlatformContextWeb().ExecuteJavaScript("Adaptive.handleFileResultCallbackError( '"+GetId()+"', JSON.parse(" + GetJSONProcessor().SerializeObject(error) +") )");
          }

          /**
             On correct result of a file operation.

             @param storageFile Reference to the resulting file.
             @since v2.0
          */
          public void OnResult(FileDescriptor storageFile)
          {
               AppRegistryBridge.GetInstance().GetPlatformContextWeb().ExecuteJavaScript("Adaptive.handleFileResultCallbackResult( '"+GetId()+"', JSON.parse(" + GetJSONProcessor().SerializeObject(storageFile) +") )");
          }

          /**
             On partial result of a file operation, containing a warning.

             @param file    Reference to the offending file.
             @param warning Warning processing the request.
             @since v2.0
          */
          public void OnWarning(FileDescriptor file, IFileResultCallbackWarning warning)
          {
               AppRegistryBridge.GetInstance().GetPlatformContextWeb().ExecuteJavaScript("Adaptive.handleFileResultCallbackWarning( '"+GetId()+"', JSON.parse(" + GetJSONProcessor().SerializeObject(file) +"), JSON.parse(" + GetJSONProcessor().SerializeObject(warning) +") )");
          }

     }
}
/**
------------------------------------| Engineered with ♥ in Barcelona, Catalonia |--------------------------------------
*/
