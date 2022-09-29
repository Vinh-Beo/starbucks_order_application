using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Project.Language;
using S3WAN.ViewModels.Login;
using S3WAN.ViewModels.Login.Help;
using Xamarin.Forms;

namespace S3WAN.Views.Login.Help
{
    public partial class HelpView : ContentPage
    {
        public HelpView()
        {
            InitializeComponent();
        }

        async void btnMenu_Clicked(System.Object sender, System.EventArgs e)
        {
            //if (BindingContext == null)
            //{
            //    return;
            //}
            //if (BindingContext.GetType() != typeof(HelpViewModel))
            //{
            //    return;
            //}

            //HelpViewModel _vm = (BindingContext as HelpViewModel);
            //EndpointViewModel Endpoint = _vm.Endpoint;
            //// Display menu to config
            //var rName = await DisplayPromptAsync(
            //                AppResources.ConfigServer,
            //                AppResources.ConfigServerDescription,
            //                AppResources.Update,
            //                AppResources.Cancel,
            //                AppResources.ConfigServerHint,
            //                64, Keyboard.Text, "");
            //if (rName == null)
            //{
            //    return;
            //}
            //string _name = rName;
            //// Checking special character
            //if (_name == "")
            //{
            //    return;
            //}
            //// check restore config default or new
            //if (_name == "DF")
            //{
            //    bool _response = false;
            //    using (UserDialogs.Instance.Loading(AppResources.DoingRestoreDefaultConfig))
            //    {
            //        string _findResourcePath = "";
            //        Assembly _assem = Assembly.GetExecutingAssembly();
            //        string[] names = _assem.GetManifestResourceNames();
            //        foreach (var item in names)
            //        {
            //            if (item.Contains(UserConstant.ConfigFilePath))
            //            {
            //                _findResourcePath = item;
            //                break;
            //            }
            //        }
            //        if (string.IsNullOrEmpty(_findResourcePath))
            //        {
            //            _response = false;
            //            return;
            //        }

            //        // Load file config
            //        try
            //        {
            //            byte[] buffer;
            //            //FileStream fileStream = new FileStream(_findResourcePath, FileMode.Open, FileAccess.Read);
            //            Stream fileStream = _assem.GetManifestResourceStream(_findResourcePath);
            //            int length = (int)fileStream.Length;  // get file length
            //            buffer = new byte[length];            // create buffer
            //            int count;                            // actual number of bytes read
            //            int sum = 0;                          // total number of bytes read

            //            // read until Read method returns 0 (end of the stream has been reached)
            //            while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
            //                sum += count;  // sum is a buffer offset for next reading

            //            string _srcStr = System.Text.Encoding.UTF8.GetString(buffer);
            //            byte[] _srcArr = Convert.FromBase64String(_srcStr);

            //            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(UserConstant.ConfigKey);
            //            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //            tdes.Key = keyArray;
            //            tdes.Mode = CipherMode.ECB;
            //            tdes.Padding = PaddingMode.PKCS7;

            //            ICryptoTransform cTransform = tdes.CreateDecryptor();
            //            byte[] _resultArr = cTransform.TransformFinalBlock(_srcArr, 0, _srcArr.Length);
            //            tdes.Clear();
            //            string _desStr = System.Text.Encoding.UTF8.GetString(_resultArr);

            //            ConfigFileClass _cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigFileClass>(_desStr);
            //            // Calculator MD5
            //            MD5 md5 = System.Security.Cryptography.MD5.Create();
            //            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(_cfg.Data));
            //            string _md5 = Convert.ToBase64String(hash);

            //            if (_cfg.MD5 != _md5)
            //            {
            //                _response = false;
            //                return;
            //            }

            //            ClientConfigClass _info = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientConfigClass>(_cfg.Data);

            //            Endpoint.LoginEndpoint = _info.LoginEndpoint;
            //            Endpoint.LoginHardKey = _info.LoginHardKey;
            //            Endpoint.ApiEndpoint = _info.ApiEndpoint;
            //            Endpoint.ApiHardKey = _info.ApiHardKey;
            //            Endpoint.PMSEndpoint = _info.PMSEndpoint;
            //            Endpoint.PMSHardKey = _info.PMSHardKey;
            //            Endpoint.CloudEndpoint = _info.CloudEndpoint;
            //            Endpoint.CloudPort = _info.CloudPort;
            //            Endpoint.CloudHardKey = _info.CloudHardKey;
            //            Endpoint.ProjectName = _info.Name;
            //            Endpoint.ClientCode = _info.ClientCode;

            //            Settings.Config = _srcStr;
            //            _response = true;
            //        }
            //        catch (Exception)
            //        {
            //            _response = false;
            //            return;
            //        }
            //    }
            //    if (!_response)
            //    {
            //        UserDialogs.Instance.Toast(new ToastConfig(AppResources.RestoreConfigFail).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //        return;
            //    }
            //    UserDialogs.Instance.Toast(new ToastConfig(AppResources.RestoreConfigOK).SetIcon("OK_32px.png"));
            //}
            //else
            //{
            //    bool response = false;
            //    using (UserDialogs.Instance.Loading(AppResources.DoingConfigServer))
            //    {
            //        S3WAN.Client.API.ResponseLoadClientConfigByCodeModel _rv = new S3WAN.Client.API.ResponseLoadClientConfigByCodeModel()
            //        {
            //            ErrorCode = S3WAN.Client.API.ResponseLoadClientConfigByCodeErrorCode.Unknown,
            //            Version = UserConstant.Version,
            //        };
            //        CancellationToken _ct = FormBase.MainViewModel.Cts.Token;
            //        try
            //        {
            //            await Task.Factory.StartNew(() =>
            //            {
            //                try
            //                {
            //                    using (S3WAN.PmsAPI.Service ser = new S3WAN.PmsAPI.Service()
            //                    {
            //                        Timeout = UserConstant.ServiceApiReceiveTimeout,
            //                        Url = Endpoint.PMSEndpoint,
            //                    })
            //                    {
            //                        Crypto crypto = new Crypto();
            //                        string _privateKey = crypto.GenKey();
            //                        S3WAN.Client.API.RequestLoadClientConfigByCodeModel _iv = new S3WAN.Client.API.RequestLoadClientConfigByCodeModel()
            //                        {
            //                            Version = UserConstant.APIVersion.ToString(),
            //                            ClientCode = _name,
            //                            Key = _privateKey
            //                        };
            //                        string _text = Convert.ToBase64String(crypto.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(_iv), Encoding.UTF8.GetBytes(Endpoint.PMSHardKey)));
            //                        string _encodeData = ser.LoadClientConfigByCode(Convert.ToBase64String(crypto.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(_iv), Encoding.UTF8.GetBytes(Endpoint.PMSHardKey))));

            //                        if (_encodeData == null || _encodeData == "")
            //                        {
            //                            response = false;
            //                            return;
            //                        }

            //                        string _retval = crypto.Decrypt(Convert.FromBase64String(_encodeData), Encoding.UTF8.GetBytes(_privateKey));
            //                        _rv = Newtonsoft.Json.JsonConvert.DeserializeObject<S3WAN.Client.API.ResponseLoadClientConfigByCodeModel>(_retval);
            //                        response = true;

            //                    }
            //                }
            //                catch (Exception)
            //                {
            //                    response = false;
            //                    return;
            //                }

            //            }, _ct);
            //        }
            //        catch (OperationCanceledException __e)
            //        {
            //            Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {__e.Message}");
            //            return;
            //        }
            //        UserDialogs.Instance.HideLoading();
            //        if (!response)
            //        {
            //            UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryUnknownError).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //            return;
            //        }
            //        if (_rv.ErrorCode != Client.API.ResponseLoadClientConfigByCodeErrorCode.OK)
            //        {
            //            if (_rv.ErrorCode == S3WAN.Client.API.ResponseLoadClientConfigByCodeErrorCode.NoPermission)
            //            {
            //                UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryYouHaveNoPermissionToDoThisAction).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //                return;
            //            }
            //            else if (_rv.ErrorCode == S3WAN.Client.API.ResponseLoadClientConfigByCodeErrorCode.ProjectNotExist)
            //            {
            //                UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryCantNotFoundInfo).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //                return;
            //            }
            //            else
            //            {
            //                UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryUnknownError).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //                return;
            //            }
            //        }

            //        // try analyse data
            //        try
            //        {
            //            string _srcStr = _rv.ConfigStr;
            //            byte[] _srcArr = Convert.FromBase64String(_srcStr);

            //            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(UserConstant.ConfigKey);
            //            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //            tdes.Key = keyArray;
            //            tdes.Mode = CipherMode.ECB;
            //            tdes.Padding = PaddingMode.PKCS7;

            //            ICryptoTransform cTransform = tdes.CreateDecryptor();
            //            byte[] _resultArr = cTransform.TransformFinalBlock(_srcArr, 0, _srcArr.Length);
            //            tdes.Clear();
            //            string _desStr = System.Text.Encoding.UTF8.GetString(_resultArr);

            //            ConfigFileClass _cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigFileClass>(_desStr);
            //            // Calculator MD5
            //            MD5 md5 = System.Security.Cryptography.MD5.Create();
            //            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(_cfg.Data));
            //            string _md5 = Convert.ToBase64String(hash);

            //            if (_cfg.MD5 != _md5)
            //            {
            //                UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryUnknownError).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //                return;
            //            }

            //            ClientConfigClass _info = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientConfigClass>(_cfg.Data);

            //            Endpoint.LoginEndpoint = _info.LoginEndpoint;
            //            Endpoint.LoginHardKey = _info.LoginHardKey;
            //            Endpoint.ApiEndpoint = _info.ApiEndpoint;
            //            Endpoint.ApiHardKey = _info.ApiHardKey;
            //            Endpoint.PMSEndpoint = _info.PMSEndpoint;
            //            Endpoint.PMSHardKey = _info.PMSHardKey;
            //            Endpoint.CloudEndpoint = _info.CloudEndpoint;
            //            Endpoint.CloudPort = _info.CloudPort;
            //            Endpoint.CloudHardKey = _info.CloudHardKey;
            //            Endpoint.ProjectName = _info.Name;
            //            Endpoint.ClientCode = _info.ClientCode;

            //            Settings.Config = _rv.ConfigStr;
            //        }
            //        catch (Exception)
            //        {
            //            UserDialogs.Instance.Toast(new ToastConfig(AppResources.SorryUnknownError).SetIcon("Close_32px.png").SetMessageTextColor(Color.Red));
            //            return;
            //        }
            //        UserDialogs.Instance.Toast(new ToastConfig(AppResources.ConfigServerOK).SetIcon("OK_32px.png"));
            //    }
            //}

            //if (_vm.BackCmd != null && _vm.BackCmd.CanExecute(null))
            //{
            //    _vm.BackCmd.Execute(null);
            //}
        }
    }
}
