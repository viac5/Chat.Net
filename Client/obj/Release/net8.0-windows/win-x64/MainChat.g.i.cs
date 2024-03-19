﻿#pragma checksum "..\..\..\..\MainChat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01E6B139D83FFF5E9BAECDEB27E87126E9620FD9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatClient;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ChatClient {
    
    
    /// <summary>
    /// MainChat
    /// </summary>
    public partial class MainChat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\MainChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUserName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\MainChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bConnDisconn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\MainChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbChat;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\MainChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMessage;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\MainChat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bSendMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/mainchat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainChat.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 2 "..\..\..\..\MainChat.xaml"
            ((ChatClient.MainChat)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 3 "..\..\..\..\MainChat.xaml"
            ((ChatClient.MainChat)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.bConnDisconn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\MainChat.xaml"
            this.bConnDisconn.Click += new System.Windows.RoutedEventHandler(this.Button_Click_ConDiscon);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbChat = ((System.Windows.Controls.ListBox)(target));
            
            #line 26 "..\..\..\..\MainChat.xaml"
            this.lbChat.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbChat_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbMessage = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\MainChat.xaml"
            this.tbMessage.KeyDown += new System.Windows.Input.KeyEventHandler(this.tbMessage_KeyDown);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\MainChat.xaml"
            this.tbMessage.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbMessage_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bSendMessage = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\MainChat.xaml"
            this.bSendMessage.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Send);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

