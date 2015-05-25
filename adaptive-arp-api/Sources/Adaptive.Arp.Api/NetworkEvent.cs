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

    * @version v2.2.13

-------------------------------------------| aut inveniam viam aut faciam |--------------------------------------------
*/

using System;

namespace Adaptive.Arp.Api
{
     /**
        Represents a network handover event on the system.

        @author Ferran Vila Conesa
        @since v2.2.1
        @version 1.0
     */
     public class NetworkEvent : APIBean
     {

          /**
             New type of network of the event
          */
          public ICapabilitiesNet Network { get; set; }
          /**
             The timestamps in milliseconds when the event was fired.
          */
          public long Timestamp { get; set; }

          /**
             Default constructor

             @since V2.2.1
          */
          public NetworkEvent()  {
          }

          /**
             Constructor used by the implementation

             @param Network   of the app
             @param Timestamp Timestamp of the event
             @since V2.2.1
          */
          public NetworkEvent(ICapabilitiesNet network, long timestamp) : base () {
               this.Network = Network;
               this.Timestamp = Timestamp;
          }

          /**
             Network event getter

             @return New network switched
             @since V2.2.1
          */
          public ICapabilitiesNet GetNetwork() {
               return this.Network;
          }

          /**
             Network setter

             @param Network New network switched
             @since V2.2.1
          */
          public void SetNetwork(ICapabilitiesNet Network) {
               this.Network = Network;
          }

          /**
             Returns the timestamp of the event

             @return Timestamp of the event
             @since V2.2.1
          */
          public long GetTimestamp() {
               return this.Timestamp;
          }

          /**
             Sets the timestamp of the event

             @param Timestamp Timestamp of the event
             @since V2.2.1
          */
          public void SetTimestamp(long Timestamp) {
               this.Timestamp = Timestamp;
          }


     }
}

/**
------------------------------------| Engineered with ♥ in Barcelona, Catalonia |--------------------------------------
*/
