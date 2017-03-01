//------------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

namespace Microsoft.IdentityModel.Tokens.Saml2
{
    using System;
    using System.Collections.ObjectModel;
    using Logging;
    using Xml;

    /// <summary>
    /// Represents the SubjectConfirmationData element and the associated 
    /// KeyInfoConfirmationDataType defined in [Saml2Core, 2.4.1.2-2.4.1.3].
    /// </summary>
    public class Saml2SubjectConfirmationData
    {
        private string address;
        private Saml2Id inResponseTo;
        private Collection<SecurityKeyIdentifier> keyIdentifiers = new Collection<SecurityKeyIdentifier>();
        private DateTime? notBefore;
        private DateTime? notOnOrAfter;
        private Uri recipient;

        /// <summary>
        /// Initializes an instance of <see cref="Saml2SubjectConfirmationData"/>.
        /// </summary>
        public Saml2SubjectConfirmationData()
        {
        }

        /// <summary>
        /// Gets or sets the network address/location from which an attesting entity can present the 
        /// assertion. [Saml2Core, 2.4.1.2]
        /// </summary>
        public string Address
        {
            get 
            { 
                return this.address; 
            }

            set
            {
                this.address = XmlUtil.NormalizeEmptyString(value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Saml2Id"/> of a SAML protocol message in response to which an attesting entity can 
        /// present the assertion. [Saml2Core, 2.4.1.2]
        /// </summary>
        public Saml2Id InResponseTo
        {
            get { return this.inResponseTo; }
            set { this.inResponseTo = value; }
        }

        /// <summary>
        /// Gets a collection of <see cref="SecurityKeyIdentifier"/> which can be used to authenticate an attesting entity. [Saml2Core, 2.4.1.3]
        /// </summary>
        public Collection<SecurityKeyIdentifier> KeyIdentifiers
        {
            get { return this.keyIdentifiers; }
        }

        /// <summary>
        /// Gets or sets a time instant before which the subject cannot be confirmed. [Saml2Core, 2.4.1.2]
        /// </summary>
        public DateTime? NotBefore
        {
            get { return this.notBefore; }
            set { this.notBefore = DateTimeUtil.ToUniversalTime(value); }
        }

        /// <summary>
        /// Gets or sets a time instant at which the subject can no longer be confirmed. [Saml2Core, 2.4.1.2]
        /// </summary>
        public DateTime? NotOnOrAfter
        {
            get { return this.notOnOrAfter; }
            set { this.notOnOrAfter = DateTimeUtil.ToUniversalTime(value); }
        }

        /// <summary>
        /// Gets or sets a URI specifying the entity or location to which an attesting entity can present 
        /// the assertion. [Saml2Core, 2.4.1.2]
        /// </summary>
        public Uri Recipient
        {
            get 
            { 
                return this.recipient; 
            }

            set
            {
                if (null != value && !value.IsAbsoluteUri)
                    throw LogHelper.LogArgumentNullException("nameof(value), ID0013");

                this.recipient = value;
            }
        }
    }
}