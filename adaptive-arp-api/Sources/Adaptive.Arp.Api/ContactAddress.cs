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

    * @version v2.2.3

-------------------------------------------| aut inveniam viam aut faciam |--------------------------------------------
*/

using System;

namespace Adaptive.Arp.Api
{
     /**
        Structure representing the address data elements of a contact.

        @author Francisco Javier Martin Bueno
        @since v2.0
        @version 1.0
     */
     public class ContactAddress : APIBean
     {

          /**
             The address type
          */
          public ContactAddressType Type { get; set; }
          /**
             The Contact address
          */
          public string Address { get; set; }

          /**
             Default constructor

             @since V2.0
          */
          public ContactAddress()  {
          }

          /**
             Constructor with fields

             @param Address Address data.
             @param Type    Address type.
             @since V2.0
          */
          public ContactAddress(string address, ContactAddressType type) : base () {
               this.Address = Address;
               this.Type = Type;
          }

          /**
             Returns the type of the address

             @return AddressType Address type.
             @since V2.0
          */
          public new ContactAddressType GetType() {
               return this.Type;
          }

          /**
             Set the address type

             @param Type Address type.
             @since V2.0
          */
          public void SetType(ContactAddressType Type) {
               this.Type = Type;
          }

          /**
             Returns the Contact address

             @return Address Address data.
             @since V2.0
          */
          public string GetAddress() {
               return this.Address;
          }

          /**
             Set the address of the Contact

             @param Address Address data.
             @since V2.0
          */
          public void SetAddress(string Address) {
               this.Address = Address;
          }


     }
}

/**
------------------------------------| Engineered with ♥ in Barcelona, Catalonia |--------------------------------------
*/
