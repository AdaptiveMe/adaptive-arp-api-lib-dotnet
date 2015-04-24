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
        Structure representing a database reference.

        @author Ferran Vila Conesa
        @since v2.0
        @version 1.0
     */
     public class Database : APIBean
     {

          /**
             Indicates if database was created or needs to be created as Compressed.
          */
          public bool Compress { get; set; }
          /**
             Database Name (name of the .db local file).
          */
          public string Name { get; set; }

          /**
             Default constructor

             @since V2.0
          */
          public Database()  {
          }

          /**
             Default constructor. The compress param is setted to false.

             @param Name Name of the table.
             @since V2.0
          */
          public Database(string name) : base () {
               this.Name = Name;
          }

          /**
             Constructor using fields.

             @param Name     Name of the DatabaseTable.
             @param Compress Compression enabled.
             @since V2.0
          */
          public Database(string name, bool compress) : base () {
               this.Name = Name;
               this.Compress = Compress;
          }

          /**
             Returns if the table is compressed

             @return Compression enabled
             @since V2.0
          */
          public bool GetCompress() {
               return this.Compress;
          }

          /**
             Sets if the table is compressed or not.

             @param Compress Compression enabled
             @since V2.0
          */
          public void SetCompress(bool Compress) {
               this.Compress = Compress;
          }

          /**
             Returns the name.

             @return The name of the table.
             @since V2.0
          */
          public string GetName() {
               return this.Name;
          }

          /**
             Sets the name of the table.

             @param Name The name of the table.
             @since V2.0
          */
          public void SetName(string Name) {
               this.Name = Name;
          }


     }
}

/**
------------------------------------| Engineered with ♥ in Barcelona, Catalonia |--------------------------------------
*/
