﻿// ----------------------------------------------------------------------------------Caatag,
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Dns.Models;
using Microsoft.Azure.Management.Dns.Models;

using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns

{
    /// <summary>
    /// Constructs an in-memory dns record object
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDnsRecordConfig"), OutputType(typeof(DnsRecordBase))]
    public class NewAzureRmDnsRecordConfig : DnsBaseCmdlet
    {
        private const string ParameterSetA = "A";
        private const string ParameterSetAaaa = "Aaaa";
        private const string ParameterSetCName = "CName";
        private const string ParameterSetTxt = "Txt";
        private const string ParameterSetSrv = "Srv";
        private const string ParameterSetPtr = "Ptr" ;
        private const string ParameterSetNs = "Ns";
        private const string ParameterSetMx = "Mx";
        private const string ParameterSetCaa = "Caa";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv4 address for the A record to add.", ParameterSetName = ParameterSetA)]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv6 address for the AAAA record to add.", ParameterSetName = ParameterSetAaaa)]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name server host for the NS record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = ParameterSetNs)]
        [ValidateNotNullOrEmpty]
        public string Nsdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The mail exchange host for the MX record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = ParameterSetMx)]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference value for the MX record to add.", ParameterSetName = ParameterSetMx)]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host for the PTR record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = ParameterSetPtr)]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The text value for the TXT record to add.", ParameterSetName = ParameterSetTxt)]
        [ValidateNotNullOrEmpty]
        [ValidateLength(DnsRecordBase.TxtRecordMinLength, DnsRecordBase.TxtRecordMaxLength)]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The priority value SRV record to add.", ParameterSetName = ParameterSetSrv)]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host for the SRV record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = ParameterSetSrv)]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The port number for the SRV record to add.", ParameterSetName = ParameterSetSrv)]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The weight value for the SRV record to add.", ParameterSetName = ParameterSetSrv)]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The canonical name for the CNAME record to add. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = ParameterSetCName)]
        [ValidateNotNullOrEmpty]
        public string Cname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The flags for the CAA record to add. Must be a number between 0 and 255.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNullOrEmpty]
        public byte CaaFlags { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The tag field of the CAA record to add.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNullOrEmpty]
        public string CaaTag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The value field for the CAA record to add.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNull]
        [AllowEmptyString]
        [ValidateLength(DnsRecordBase.CaaRecordMinLength, DnsRecordBase.CaaRecordMaxLength)]
        public string CaaValue { get; set; }

        public override void ExecuteCmdlet()
        {
            DnsRecordBase result = null;
            switch (ParameterSetName)
            {
                case ParameterSetA:
                    {
                        result = new ARecord { Ipv4Address = Ipv4Address };
                        break;
                    }

                case ParameterSetAaaa:
                    {
                        result = new AaaaRecord { Ipv6Address = Ipv6Address };
                        break;
                    }

                case ParameterSetMx:
                    {
                        result = new MxRecord { Preference = Preference, Exchange = Exchange };
                        break;
                    }

                case ParameterSetNs:
                    {
                        result = new NsRecord { Nsdname = Nsdname };
                        break;
                    }
                case ParameterSetSrv:
                    {
                        result = new SrvRecord { Priority = Priority, Port = Port, Target = Target, Weight = Weight };
                        break;
                    }
                case ParameterSetTxt:
                    {
                        result = new TxtRecord { Value = Value };
                        break;
                    }
                case ParameterSetCName:
                    {
                        result = new CnameRecord { Cname = Cname };
                        break;
                    }
                case ParameterSetPtr:
                    {
                        result = new PtrRecord {Ptrdname = Ptrdname};
                        break;
                    }
                case ParameterSetCaa:
                    {
                        result = new CaaRecord { Flags = CaaFlags, Tag = CaaTag, Value = CaaValue};
                        break;
                    }
                default:
                    {
                        throw new PSArgumentException(string.Format(ProjectResources.Error_UnknownParameterSetName, ParameterSetName));
                    }
            }

            WriteObject(result);
        }
    }
}
