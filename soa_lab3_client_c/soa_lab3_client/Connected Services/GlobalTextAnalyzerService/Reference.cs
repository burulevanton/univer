//------------------------------------------------------------------------------
// <автоматически создаваемое>
//     Этот код создан программой.
//     //
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </автоматически создаваемое>
//------------------------------------------------------------------------------

namespace GlobalTextAnalyzerService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="globalTextAnalyzer", ConfigurationName="GlobalTextAnalyzerService.GlobalTextAnalyzer")]
    public interface GlobalTextAnalyzer
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="count_one_word", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_one_wordResponse1> count_one_wordAsync(GlobalTextAnalyzerService.count_one_word1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="count_characters", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_charactersResponse1> count_charactersAsync(GlobalTextAnalyzerService.count_characters1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="count_words", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_wordsResponse1> count_wordsAsync(GlobalTextAnalyzerService.count_words1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="make_caps", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.make_capsResponse1> make_capsAsync(GlobalTextAnalyzerService.make_caps1 request);
        
        [System.ServiceModel.OperationContractAttribute(Action="count_words_on_web_page", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_words_on_web_pageResponse1> count_words_on_web_pageAsync(GlobalTextAnalyzerService.count_words_on_web_page1 request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_one_word
    {
        
        private string wordField;
        
        private string textField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string word
        {
            get
            {
                return this.wordField;
            }
            set
            {
                this.wordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_words_on_web_pageResponse
    {
        
        private Pair[] count_words_on_web_pageResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Order=0)]
        public Pair[] count_words_on_web_pageResult
        {
            get
            {
                return this.count_words_on_web_pageResultField;
            }
            set
            {
                this.count_words_on_web_pageResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class Pair
    {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", IsNullable=true, Order=1)]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_words_on_web_page
    {
        
        private string urlField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class make_capsResponse
    {
        
        private string make_capsResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string make_capsResult
        {
            get
            {
                return this.make_capsResultField;
            }
            set
            {
                this.make_capsResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class make_caps
    {
        
        private string textField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_wordsResponse
    {
        
        private Pair[] count_wordsResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Order=0)]
        public Pair[] count_wordsResult
        {
            get
            {
                return this.count_wordsResultField;
            }
            set
            {
                this.count_wordsResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_words
    {
        
        private string textField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_charactersResponse
    {
        
        private Pair[] count_charactersResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Order=0)]
        public Pair[] count_charactersResult
        {
            get
            {
                return this.count_charactersResultField;
            }
            set
            {
                this.count_charactersResultField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_characters
    {
        
        private string textField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="globalTextAnalyzer")]
    public partial class count_one_wordResponse
    {
        
        private string count_one_wordResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", IsNullable=true, Order=0)]
        public string count_one_wordResult
        {
            get
            {
                return this.count_one_wordResultField;
            }
            set
            {
                this.count_one_wordResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_one_word1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_one_word count_one_word;
        
        public count_one_word1()
        {
        }
        
        public count_one_word1(GlobalTextAnalyzerService.count_one_word count_one_word)
        {
            this.count_one_word = count_one_word;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_one_wordResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_one_wordResponse count_one_wordResponse;
        
        public count_one_wordResponse1()
        {
        }
        
        public count_one_wordResponse1(GlobalTextAnalyzerService.count_one_wordResponse count_one_wordResponse)
        {
            this.count_one_wordResponse = count_one_wordResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_characters1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_characters count_characters;
        
        public count_characters1()
        {
        }
        
        public count_characters1(GlobalTextAnalyzerService.count_characters count_characters)
        {
            this.count_characters = count_characters;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_charactersResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_charactersResponse count_charactersResponse;
        
        public count_charactersResponse1()
        {
        }
        
        public count_charactersResponse1(GlobalTextAnalyzerService.count_charactersResponse count_charactersResponse)
        {
            this.count_charactersResponse = count_charactersResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_words1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_words count_words;
        
        public count_words1()
        {
        }
        
        public count_words1(GlobalTextAnalyzerService.count_words count_words)
        {
            this.count_words = count_words;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_wordsResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_wordsResponse count_wordsResponse;
        
        public count_wordsResponse1()
        {
        }
        
        public count_wordsResponse1(GlobalTextAnalyzerService.count_wordsResponse count_wordsResponse)
        {
            this.count_wordsResponse = count_wordsResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class make_caps1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.make_caps make_caps;
        
        public make_caps1()
        {
        }
        
        public make_caps1(GlobalTextAnalyzerService.make_caps make_caps)
        {
            this.make_caps = make_caps;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class make_capsResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.make_capsResponse make_capsResponse;
        
        public make_capsResponse1()
        {
        }
        
        public make_capsResponse1(GlobalTextAnalyzerService.make_capsResponse make_capsResponse)
        {
            this.make_capsResponse = make_capsResponse;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_words_on_web_page1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_words_on_web_page count_words_on_web_page;
        
        public count_words_on_web_page1()
        {
        }
        
        public count_words_on_web_page1(GlobalTextAnalyzerService.count_words_on_web_page count_words_on_web_page)
        {
            this.count_words_on_web_page = count_words_on_web_page;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class count_words_on_web_pageResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="globalTextAnalyzer", Order=0)]
        public GlobalTextAnalyzerService.count_words_on_web_pageResponse count_words_on_web_pageResponse;
        
        public count_words_on_web_pageResponse1()
        {
        }
        
        public count_words_on_web_pageResponse1(GlobalTextAnalyzerService.count_words_on_web_pageResponse count_words_on_web_pageResponse)
        {
            this.count_words_on_web_pageResponse = count_words_on_web_pageResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface GlobalTextAnalyzerChannel : GlobalTextAnalyzerService.GlobalTextAnalyzer, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class GlobalTextAnalyzerClient : System.ServiceModel.ClientBase<GlobalTextAnalyzerService.GlobalTextAnalyzer>, GlobalTextAnalyzerService.GlobalTextAnalyzer
    {
        
    /// <summary>
    /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
    /// </summary>
    /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
    /// <param name="clientCredentials">Учетные данные клиента.</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public GlobalTextAnalyzerClient() : 
                base(GlobalTextAnalyzerClient.GetDefaultBinding(), GlobalTextAnalyzerClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.GlobalTextAnalyzer.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GlobalTextAnalyzerClient(EndpointConfiguration endpointConfiguration) : 
                base(GlobalTextAnalyzerClient.GetBindingForEndpoint(endpointConfiguration), GlobalTextAnalyzerClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GlobalTextAnalyzerClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(GlobalTextAnalyzerClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GlobalTextAnalyzerClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(GlobalTextAnalyzerClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GlobalTextAnalyzerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_one_wordResponse1> GlobalTextAnalyzerService.GlobalTextAnalyzer.count_one_wordAsync(GlobalTextAnalyzerService.count_one_word1 request)
        {
            return base.Channel.count_one_wordAsync(request);
        }
        
        public System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_one_wordResponse1> count_one_wordAsync(GlobalTextAnalyzerService.count_one_word count_one_word)
        {
            GlobalTextAnalyzerService.count_one_word1 inValue = new GlobalTextAnalyzerService.count_one_word1();
            inValue.count_one_word = count_one_word;
            return ((GlobalTextAnalyzerService.GlobalTextAnalyzer)(this)).count_one_wordAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_charactersResponse1> GlobalTextAnalyzerService.GlobalTextAnalyzer.count_charactersAsync(GlobalTextAnalyzerService.count_characters1 request)
        {
            return base.Channel.count_charactersAsync(request);
        }
        
        public System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_charactersResponse1> count_charactersAsync(GlobalTextAnalyzerService.count_characters count_characters)
        {
            GlobalTextAnalyzerService.count_characters1 inValue = new GlobalTextAnalyzerService.count_characters1();
            inValue.count_characters = count_characters;
            return ((GlobalTextAnalyzerService.GlobalTextAnalyzer)(this)).count_charactersAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_wordsResponse1> GlobalTextAnalyzerService.GlobalTextAnalyzer.count_wordsAsync(GlobalTextAnalyzerService.count_words1 request)
        {
            return base.Channel.count_wordsAsync(request);
        }
        
        public System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_wordsResponse1> count_wordsAsync(GlobalTextAnalyzerService.count_words count_words)
        {
            GlobalTextAnalyzerService.count_words1 inValue = new GlobalTextAnalyzerService.count_words1();
            inValue.count_words = count_words;
            return ((GlobalTextAnalyzerService.GlobalTextAnalyzer)(this)).count_wordsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.make_capsResponse1> GlobalTextAnalyzerService.GlobalTextAnalyzer.make_capsAsync(GlobalTextAnalyzerService.make_caps1 request)
        {
            return base.Channel.make_capsAsync(request);
        }
        
        public System.Threading.Tasks.Task<GlobalTextAnalyzerService.make_capsResponse1> make_capsAsync(GlobalTextAnalyzerService.make_caps make_caps)
        {
            GlobalTextAnalyzerService.make_caps1 inValue = new GlobalTextAnalyzerService.make_caps1();
            inValue.make_caps = make_caps;
            return ((GlobalTextAnalyzerService.GlobalTextAnalyzer)(this)).make_capsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_words_on_web_pageResponse1> GlobalTextAnalyzerService.GlobalTextAnalyzer.count_words_on_web_pageAsync(GlobalTextAnalyzerService.count_words_on_web_page1 request)
        {
            return base.Channel.count_words_on_web_pageAsync(request);
        }
        
        public System.Threading.Tasks.Task<GlobalTextAnalyzerService.count_words_on_web_pageResponse1> count_words_on_web_pageAsync(GlobalTextAnalyzerService.count_words_on_web_page count_words_on_web_page)
        {
            GlobalTextAnalyzerService.count_words_on_web_page1 inValue = new GlobalTextAnalyzerService.count_words_on_web_page1();
            inValue.count_words_on_web_page = count_words_on_web_page;
            return ((GlobalTextAnalyzerService.GlobalTextAnalyzer)(this)).count_words_on_web_pageAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.GlobalTextAnalyzer))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.GlobalTextAnalyzer))
            {
                return new System.ServiceModel.EndpointAddress("http://54.164.148.35:9000/");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return GlobalTextAnalyzerClient.GetBindingForEndpoint(EndpointConfiguration.GlobalTextAnalyzer);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return GlobalTextAnalyzerClient.GetEndpointAddress(EndpointConfiguration.GlobalTextAnalyzer);
        }
        
        public enum EndpointConfiguration
        {
            
            GlobalTextAnalyzer,
        }
    }
}
