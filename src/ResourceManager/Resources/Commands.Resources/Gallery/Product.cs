﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Resources.Models.Gallery
{
    /// <summary>
    /// A gallery item product definition.
    /// </summary>
    public partial class Product
    {
        private string _displayName;

        /// <summary>
        /// Optional. Gets or sets product display name.
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        private string _legalTermsUri;

        /// <summary>
        /// Optional. Gets or sets product legal terms Uri.
        /// </summary>
        public string LegalTermsUri
        {
            get { return _legalTermsUri; }
            set { _legalTermsUri = value; }
        }

        private OfferDetails _offerDetails;

        /// <summary>
        /// Optional. Gets or sets product offer details.
        /// </summary>
        public OfferDetails OfferDetails
        {
            get { return _offerDetails; }
            set { _offerDetails = value; }
        }

        private string _pricingDetailsUri;

        /// <summary>
        /// Optional. Gets or sets product pricing details Uri.
        /// </summary>
        public string PricingDetailsUri
        {
            get { return _pricingDetailsUri; }
            set { _pricingDetailsUri = value; }
        }

        private string _privacyPolicyUri;

        /// <summary>
        /// Optional. Gets or sets product privacy policy Uri.
        /// </summary>
        public string PrivacyPolicyUri
        {
            get { return _privacyPolicyUri; }
            set { _privacyPolicyUri = value; }
        }

        private string _publisherDisplayName;

        /// <summary>
        /// Optional. Gets or sets product publisher display name.
        /// </summary>
        public string PublisherDisplayName
        {
            get { return _publisherDisplayName; }
            set { _publisherDisplayName = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
        }
    }
}