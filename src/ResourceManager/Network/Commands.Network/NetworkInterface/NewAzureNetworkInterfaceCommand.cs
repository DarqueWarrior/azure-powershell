

// ----------------------------------------------------------------------------------
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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkInterface", SupportsShouldProcess = true,
        DefaultParameterSetName = "SetByIpConfigurationResource"), OutputType(typeof(PSNetworkInterface))]
    public class NewAzureNetworkInterfaceCommand : NetworkInterfaceBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [LocationCompleter("Microsoft.Network/networkInterfaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResourceId",
            HelpMessage = "List of IpConfigurations")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResource",
            HelpMessage = "List of IpConfigurations")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkInterfaceIPConfiguration> IpConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "Subnet")]
        public PSSubnet Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "PublicIpAddressId")]
        public string PublicIpAddressId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResourceId",
            HelpMessage = "NetworkSecurityGroup")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "NetworkSecurityGroupId")]
        public string NetworkSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByIpConfigurationResourceId",
            HelpMessage = "NetworkSecurityGroup")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "NetworkSecurityGroup")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "LoadBalancerBackendAddressPoolId")]
        public List<string> LoadBalancerBackendAddressPoolId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "LoadBalancerBackendAddressPools")]
        public List<PSBackendAddressPool> LoadBalancerBackendAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "LoadBalancerInboundNatRuleId")]
        public List<string> LoadBalancerInboundNatRuleId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "LoadBalancerInboundNatRule")]
        public List<PSInboundNatRule> LoadBalancerInboundNatRule { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "ApplicationGatewayBackendAddressPoolId")]
        public List<string> ApplicationGatewayBackendAddressPoolId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "ApplicationGatewayBackendAddressPools")]
        public List<PSApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "ApplicationSecurityGroupId")]
        public List<string> ApplicationSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "ApplicationSecurityGroup")]
        public List<PSApplicationSecurityGroup> ApplicationSecurityGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The private ip address of the Network Interface " +
                          "if static allocation is specified.")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "The private ip address of the Network Interface " +
                          "if static allocation is specified.")]
        public string PrivateIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfiguration name." +
                          "default value: ipconfig1")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Dns Servers")]
        public List<string> DnsServer { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Internal Dns name")]
        public string InternalDnsNameLabel { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "EnableIPForwarding")]
        public SwitchParameter EnableIPForwarding { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "EnableAcceleratedNetworking")]
        public SwitchParameter EnableAcceleratedNetworking { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }


        public override void Execute()
        {           
          base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = IsNetworkInterfacePresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkInterface = CreateNetworkInterface();
                    if (present)
                    {
                        networkInterface = GetNetworkInterface(ResourceGroupName, Name);
                    }

                    WriteObject(networkInterface);
                },
                () => present);
        }

        private PSNetworkInterface CreateNetworkInterface()
        {
            var networkInterface = new PSNetworkInterface();
            networkInterface.Name = Name;

            networkInterface.Location = Location;

            networkInterface.EnableIPForwarding = EnableIPForwarding.IsPresent;
            networkInterface.EnableAcceleratedNetworking = EnableAcceleratedNetworking.IsPresent;

            // Get the subnetId and publicIpAddressId from the object if specified
            if (ParameterSetName.Contains(Properties.Resources.SetByIpConfiguration))
            {
                networkInterface.IpConfigurations = IpConfiguration;

                if (string.Equals(ParameterSetName, Properties.Resources.SetByIpConfigurationResourceId))
                {
                    if (NetworkSecurityGroup != null)
                    {
                        NetworkSecurityGroupId = NetworkSecurityGroup.Id;
                    }
                }
            }
            else
            {
                if (string.Equals(ParameterSetName, Properties.Resources.SetByResource))
                {
                    SubnetId = Subnet.Id;

                    if (PublicIpAddress != null)
                    {
                        PublicIpAddressId = PublicIpAddress.Id;
                    }

                    if (NetworkSecurityGroup != null)
                    {
                        NetworkSecurityGroupId = NetworkSecurityGroup.Id;
                    }

                    if (LoadBalancerBackendAddressPool != null)
                    {
                        LoadBalancerBackendAddressPoolId = new List<string>();
                        foreach (var bepool in LoadBalancerBackendAddressPool)
                        {
                            LoadBalancerBackendAddressPoolId.Add(bepool.Id);
                        }
                    }

                    if (LoadBalancerInboundNatRule != null)
                    {
                        LoadBalancerInboundNatRuleId = new List<string>();
                        foreach (var natRule in LoadBalancerInboundNatRule)
                        {
                            LoadBalancerInboundNatRuleId.Add(natRule.Id);
                        }
                    }

                    if (ApplicationGatewayBackendAddressPool != null)
                    {
                        ApplicationGatewayBackendAddressPoolId = new List<string>();
                        foreach (var appgwBepool in ApplicationGatewayBackendAddressPool)
                        {
                            ApplicationGatewayBackendAddressPoolId.Add(appgwBepool.Id);
                        }
                    }

                    if (ApplicationSecurityGroup != null)
                    {
                        ApplicationSecurityGroupId = new List<string>();
                        foreach (var asg in ApplicationSecurityGroup)
                        {
                            ApplicationSecurityGroupId.Add(asg.Id);
                        }
                    }
                }

                var nicIpConfiguration = new PSNetworkInterfaceIPConfiguration();
                nicIpConfiguration.Name = string.IsNullOrEmpty(IpConfigurationName) ? "ipconfig1" : IpConfigurationName;
                nicIpConfiguration.PrivateIpAllocationMethod = MNM.IPAllocationMethod.Dynamic;
                nicIpConfiguration.Primary = true;
                // Uncomment when ipv6 is supported as standalone ipconfig in a nic
                // nicIpConfiguration.PrivateIpAddressVersion = this.PrivateIpAddressVersion;

                if (!string.IsNullOrEmpty(PrivateIpAddress))
                {
                    nicIpConfiguration.PrivateIpAddress = PrivateIpAddress;
                    nicIpConfiguration.PrivateIpAllocationMethod = MNM.IPAllocationMethod.Static;
                }

                nicIpConfiguration.Subnet = new PSSubnet();
                nicIpConfiguration.Subnet.Id = SubnetId;

                if (!string.IsNullOrEmpty(PublicIpAddressId))
                {
                    nicIpConfiguration.PublicIpAddress = new PSPublicIpAddress();
                    nicIpConfiguration.PublicIpAddress.Id = PublicIpAddressId;
                }

                if (LoadBalancerBackendAddressPoolId != null)
                {
                    nicIpConfiguration.LoadBalancerBackendAddressPools = new List<PSBackendAddressPool>();
                    foreach (var bepoolId in LoadBalancerBackendAddressPoolId)
                    {
                        nicIpConfiguration.LoadBalancerBackendAddressPools.Add(new PSBackendAddressPool { Id = bepoolId });
                    }
                }

                if (LoadBalancerInboundNatRuleId != null)
                {
                    nicIpConfiguration.LoadBalancerInboundNatRules = new List<PSInboundNatRule>();
                    foreach (var natruleId in LoadBalancerInboundNatRuleId)
                    {
                        nicIpConfiguration.LoadBalancerInboundNatRules.Add(new PSInboundNatRule { Id = natruleId });
                    }
                }

                if (ApplicationGatewayBackendAddressPoolId != null)
                {
                    nicIpConfiguration.ApplicationGatewayBackendAddressPools = new List<PSApplicationGatewayBackendAddressPool>();
                    foreach (var appgwBepoolId in ApplicationGatewayBackendAddressPoolId)
                    {
                        nicIpConfiguration.ApplicationGatewayBackendAddressPools.Add(new PSApplicationGatewayBackendAddressPool { Id = appgwBepoolId });
                    }
                }

                if (ApplicationSecurityGroupId != null)
                {
                    nicIpConfiguration.ApplicationSecurityGroups = new List<PSApplicationSecurityGroup>();
                    foreach (var id in ApplicationSecurityGroupId)
                    {
                        nicIpConfiguration.ApplicationSecurityGroups.Add(new PSApplicationSecurityGroup { Id = id });
                    }
                }

                networkInterface.IpConfigurations = new List<PSNetworkInterfaceIPConfiguration>();
                networkInterface.IpConfigurations.Add(nicIpConfiguration);
            }

            if (DnsServer != null || InternalDnsNameLabel != null)
            {
                networkInterface.DnsSettings = new PSNetworkInterfaceDnsSettings();
                if (DnsServer != null)
                {
                    networkInterface.DnsSettings.DnsServers = DnsServer;
                }
                if (InternalDnsNameLabel != null)
                {
                    networkInterface.DnsSettings.InternalDnsNameLabel = InternalDnsNameLabel;
                }

            }

            if (!string.IsNullOrEmpty(NetworkSecurityGroupId))
            {
                networkInterface.NetworkSecurityGroup = new PSNetworkSecurityGroup();
                networkInterface.NetworkSecurityGroup.Id = NetworkSecurityGroupId;
            }

            var networkInterfaceModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkInterface>(networkInterface);

			NullifyApplicationSecurityGroupIfAbsent(networkInterfaceModel);

			networkInterfaceModel.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            NetworkInterfaceClient.CreateOrUpdate(ResourceGroupName, Name, networkInterfaceModel);
             
            var getNetworkInterface = GetNetworkInterface(ResourceGroupName, Name);

            return getNetworkInterface;
        }
    }
}

