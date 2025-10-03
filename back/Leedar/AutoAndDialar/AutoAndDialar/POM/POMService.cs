using POMAgent;
using Shared.DTOs.POM;
using Shared.Interfaces.Services;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace AutoAndDialar.POM
{
    public class POMService : IPOMService
    {

        VP_POMAgentAPIServiceClient _client = new();
        private readonly AVAYAPOMSettings _AVAYAPOMSettings;
        public POMService(AVAYAPOMSettings aVAYAPOMSettings)
        {
            _AVAYAPOMSettings = aVAYAPOMSettings;

        }

        private void Build()
        {
            //_client = new VP_POMAgentAPIServiceClient(new VP_POMAgentAPIServiceClient.EndpointConfiguration(), "http://192.168.32.30/axis2/services/VP_POMAgentAPIService/");
            if (_client.ClientCredentials != null)
            {

                _client.ClientCredentials.UserName.UserName = _AVAYAPOMSettings.UserName;
                _client.ClientCredentials.UserName.Password = _AVAYAPOMSettings.Password;
                _client.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication =
                _client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
                    new X509ServiceCertificateAuthentication
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = X509RevocationMode.NoCheck,
                        TrustedStoreLocation = StoreLocation.LocalMachine
                    };

                OperationContextScope scope = new OperationContextScope(_client.InnerChannel);
                HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
                httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " +
                Convert.ToBase64String(Encoding.ASCII.GetBytes(_client.ClientCredentials.UserName.UserName + ":" + _client.ClientCredentials.UserName.Password));
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;


                //_client.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication =
                //              _client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
                //                  new X509ServiceCertificateAuthentication
                //                  {
                //                      CertificateValidationMode = X509CertificateValidationMode.None,
                //                      RevocationMode = X509RevocationMode.NoCheck,
                //                      TrustedStoreLocation = StoreLocation.LocalMachine
                //                  };


                ////_client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                ////BasicHttpBinding binding = new BasicHttpBinding();
                ////binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
                ////binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                ////WSHttpBinding ws = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);

                //OperationContextScope scope = new OperationContextScope(_client.InnerChannel);

                //HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
                //httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " +
                //               Convert.ToBase64String(Encoding.ASCII.GetBytes(_client.ClientCredentials.UserName.UserName + ":" + _client.ClientCredentials.UserName.Password));
                //OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
            }
        }

        public async Task<bool> SaveContactToListAsync(
                Guid callId,
                Guid campaginId,
                Guid productId,
                Guid ContactId,
                string phoneNumber, string listName, int priority = 10, string agentID = "")
        {
            try
            {

                if (_client.State != CommunicationState.Opened && _client.State != CommunicationState.Opening)
                {
                    Build();
                }

                if (phoneNumber.Length > 9)
                {
                    phoneNumber = phoneNumber.Substring(phoneNumber.Length - 9);
                }


                AttributeType[] attributeTypes = new AttributeType[6];
                if (!string.IsNullOrEmpty(agentID))
                {
                    attributeTypes[0] = new AttributeType
                    {
                        Name = "agentID",
                        Value = agentID,
                    };
                    attributeTypes[1] = new AttributeType
                    {
                        Name = "CallID",
                        Value = callId.ToString(),
                    };
                    attributeTypes[2] = new AttributeType
                    {
                        Name = "CampaginId",
                        Value = campaginId.ToString(),
                    };
                    attributeTypes[3] = new AttributeType
                    {
                        Name = "ProductId",
                        Value = productId.ToString(),
                    };
                    attributeTypes[4] = new AttributeType
                    {
                        Name = "CallContactId",
                        Value = ContactId.ToString(),
                    };
                    attributeTypes[5] = new AttributeType
                    {
                        Name = "PriorityCustom",
                        Value = priority.ToString(),
                    };

                    var contact = new ContactDataType
                    {
                        ContactListName = listName,
                        UserContactId = callId.ToString(),
                        PhoneNumber1 = phoneNumber,
                        AttributeObj = attributeTypes,
                        TimeZone = "Asia/Riyadh",
                    };


                    try
                    {
                        await DeleteContactFromListAsync(contact.UserContactId, contact.ContactListName);
                    }
                    catch (Exception ex)
                    {
                    }

                    var Result = await _client.SaveContactToListAsync(contact, true, true, false, false, false, false, false);
                    // var Result = await wsclient.SaveContactToListAsync(contact, true, true, false, false, false, false, false);
                }
                else
                {
                    attributeTypes[0] = new AttributeType
                    {
                        Name = "CallID",
                        Value = callId.ToString(),
                    };
                    attributeTypes[1] = new AttributeType
                    {
                        Name = "CampaginId",
                        Value = campaginId.ToString(),
                    };
                    attributeTypes[2] = new AttributeType
                    {
                        Name = "ProductId",
                        Value = productId.ToString(),
                    };
                    attributeTypes[3] = new AttributeType
                    {
                        Name = "CallContactId",
                        Value = ContactId.ToString(),
                    };
                    attributeTypes[4] = new AttributeType
                    {
                        Name = "PriorityCustom",
                        Value = priority.ToString(),
                    };
                    var contact = new ContactDataType
                    {
                        ContactListName = listName,
                        UserContactId = callId.ToString(),
                        PhoneNumber1 = phoneNumber,
                        AttributeObj = attributeTypes,
                        TimeZone = "Asia/Riyadh",
                    };

                    try
                    {
                        await DeleteContactFromListAsync(contact.UserContactId, contact.ContactListName);
                    }
                    catch (Exception ex)
                    {
                    }

                    var Result = await _client.SaveContactToListAsync(contact, true, true, false, false, false, false, false);
                    // var Result = await wsclient.SaveContactToListAsync(contact, true, true, false, false, false, false, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                var exception = ex;
                // return 0;
                return false;
            }
        }
        public async Task<bool> DeleteContactFromListAsync(string contactId, string ListName)
        {
            try
            {
                if (_client.State != CommunicationState.Opened && _client.State != CommunicationState.Opening)
                {
                    Build();
                }
                var Result = await _client.DeleteContactFromListAsync(contactId, ListName);
                return true;
            }
            catch (Exception ex)
            {
                //var dynamicException = (dynamic)ex;
                var exception = ex;
                // return 0;
                return false;
            }
        }

        public Task<SaveContactToListPOMResult> GeneralSaveContactToListAsync(SaveContactToListPOMRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
