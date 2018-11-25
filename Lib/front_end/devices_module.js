WebInspector.DevicesView=function()
{WebInspector.VBox.call(this,true);this.registerRequiredCSS("devices/devicesView.css");this.contentElement.classList.add("devices-view");var hbox=this.contentElement.createChild("div","hbox flex-auto");var sidebar=hbox.createChild("div","devices-sidebar");sidebar.createChild("div","devices-view-title").createTextChild(WebInspector.UIString("Devices"));this._sidebarList=sidebar.createChild("div","devices-sidebar-list");this._discoveryView=new WebInspector.DevicesView.DiscoveryView();this._sidebarListSpacer=this._sidebarList.createChild("div","devices-sidebar-spacer");this._discoveryListItem=this._sidebarList.createChild("div","devices-sidebar-item");this._discoveryListItem.textContent=WebInspector.UIString("Settings");this._discoveryListItem.addEventListener("click",this._selectSidebarListItem.bind(this,this._discoveryListItem,this._discoveryView));this._viewById=new Map();this._devices=[];this._listItemById=new Map();this._viewContainer=hbox.createChild("div","flex-auto vbox");var discoveryFooter=this.contentElement.createChild("div","devices-footer");this._deviceCountSpan=discoveryFooter.createChild("span");discoveryFooter.createChild("span").textContent=WebInspector.UIString(" Read ");discoveryFooter.appendChild(WebInspector.linkifyURLAsNode("https://developers.google.com/chrome-developer-tools/docs/remote-debugging",WebInspector.UIString("remote debugging documentation"),undefined,true));discoveryFooter.createChild("span").textContent=WebInspector.UIString(" for more information.");this._updateFooter();this._selectSidebarListItem(this._discoveryListItem,this._discoveryView);InspectorFrontendHost.events.addEventListener(InspectorFrontendHostAPI.Events.DevicesUpdated,this._devicesUpdated,this);InspectorFrontendHost.events.addEventListener(InspectorFrontendHostAPI.Events.DevicesDiscoveryConfigChanged,this._devicesDiscoveryConfigChanged,this);this.contentElement.tabIndex=0;this.setDefaultFocusedElement(this.contentElement);}
WebInspector.DevicesView.prototype={_selectSidebarListItem:function(listItem,view)
{if(this._selectedListItem===listItem)
return;if(this._selectedListItem){this._selectedListItem.classList.remove("selected");this._visibleView.detach();}
this._visibleView=view;this._selectedListItem=listItem;this._visibleView.show(this._viewContainer);this._selectedListItem.classList.add("selected");},_devicesUpdated:function(event)
{this._devices=(event.data).slice();for(var device of this._devices){if(!device.adbConnected)
device.adbModel=WebInspector.UIString("Unknown");}
var ids=new Set();for(var device of this._devices)
ids.add(device.id);var selectedRemoved=false;for(var deviceId of this._viewById.keys()){if(!ids.has(deviceId)){var listItem=(this._listItemById.get(deviceId));this._listItemById.remove(deviceId);this._viewById.remove(deviceId);listItem.remove();if(listItem===this._selectedListItem)
selectedRemoved=true;}}
for(var device of this._devices){var view=this._viewById.get(device.id);var listItem=this._listItemById.get(device.id);if(!view){view=new WebInspector.DevicesView.DeviceView();this._viewById.set(device.id,view);listItem=this._createSidebarListItem(view);this._listItemById.set(device.id,listItem);this._sidebarList.insertBefore(listItem,this._sidebarListSpacer);}
listItem._title.textContent=device.adbModel;listItem._status.textContent=device.adbConnected?WebInspector.UIString("Connected"):WebInspector.UIString("Pending Authorization");listItem.classList.toggle("device-connected",device.adbConnected);view.update(device);}
if(selectedRemoved)
this._selectSidebarListItem(this._discoveryListItem,this._discoveryView);this._updateFooter();},_createSidebarListItem:function(view)
{var listItem=createElementWithClass("div","devices-sidebar-item");listItem.addEventListener("click",this._selectSidebarListItem.bind(this,listItem,view));listItem._title=listItem.createChild("div","devices-sidebar-item-title");listItem._status=listItem.createChild("div","devices-sidebar-item-status");return listItem;},_devicesDiscoveryConfigChanged:function(event)
{var discoverUsbDevices=(event.data["discoverUsbDevices"]);var portForwardingEnabled=(event.data["portForwardingEnabled"]);var portForwardingConfig=(event.data["portForwardingConfig"]);this._discoveryView.discoveryConfigChanged(discoverUsbDevices,portForwardingEnabled,portForwardingConfig);},_updateFooter:function()
{this._deviceCountSpan.textContent=!this._devices.length?WebInspector.UIString("No devices detected."):this._devices.length===1?WebInspector.UIString("1 device detected."):WebInspector.UIString("%d devices detected.",this._devices.length);},wasShown:function()
{WebInspector.PanelWithSidebar.prototype.wasShown.call(this);InspectorFrontendHost.setDevicesUpdatesEnabled(true);},willHide:function()
{WebInspector.PanelWithSidebar.prototype.wasShown.call(this);InspectorFrontendHost.setDevicesUpdatesEnabled(false);},__proto__:WebInspector.VBox.prototype}
WebInspector.DevicesView._instance=function()
{if(!WebInspector.DevicesView._instanceObject)
WebInspector.DevicesView._instanceObject=new WebInspector.DevicesView();return WebInspector.DevicesView._instanceObject;}
WebInspector.DevicesView.DiscoveryView=function()
{WebInspector.VBox.call(this);this.setMinimumSize(100,100);this.element.classList.add("discovery-view");this.contentElement.createChild("div","hbox device-text-row").createChild("div","view-title").textContent=WebInspector.UIString("Settings");var discoverUsbDevicesCheckbox=createCheckboxLabel(WebInspector.UIString("Discover USB devices"));discoverUsbDevicesCheckbox.classList.add("usb-checkbox");this.element.appendChild(discoverUsbDevicesCheckbox);this._discoverUsbDevicesCheckbox=discoverUsbDevicesCheckbox.checkboxElement;this._discoverUsbDevicesCheckbox.addEventListener("click",this._updateDiscoveryConfig.bind(this),false);var help=this.element.createChild("div","discovery-help");help.createChild("span").textContent=WebInspector.UIString("Need help? Read Chrome ");help.appendChild(WebInspector.linkifyURLAsNode("https://developers.google.com/chrome-developer-tools/docs/remote-debugging",WebInspector.UIString("remote debugging documentation."),undefined,true));var portForwardingHeader=this.element.createChild("div","port-forwarding-header");var portForwardingEnabledCheckbox=createCheckboxLabel(WebInspector.UIString("Port forwarding"));portForwardingEnabledCheckbox.classList.add("port-forwarding-checkbox");portForwardingHeader.appendChild(portForwardingEnabledCheckbox);this._portForwardingEnabledCheckbox=portForwardingEnabledCheckbox.checkboxElement;this._portForwardingEnabledCheckbox.addEventListener("click",this._updateDiscoveryConfig.bind(this),false);var portForwardingFooter=this.element.createChild("div","port-forwarding-footer");portForwardingFooter.createChild("span").textContent=WebInspector.UIString("Define the listening port on your device that maps to a port accessible from your development machine. ");portForwardingFooter.appendChild(WebInspector.linkifyURLAsNode("https://developer.chrome.com/devtools/docs/remote-debugging#port-forwarding",WebInspector.UIString("Learn more"),undefined,true));this._list=new WebInspector.ListWidget(this);this._list.registerRequiredCSS("devices/devicesView.css");this._list.element.classList.add("port-forwarding-list");var placeholder=createElementWithClass("div","port-forwarding-list-empty");placeholder.textContent=WebInspector.UIString("No rules");this._list.setEmptyPlaceholder(placeholder);this._list.show(this.element);this.element.appendChild(createTextButton(WebInspector.UIString("Add rule"),this._addRuleButtonClicked.bind(this),"add-rule-button"));this._portForwardingConfig=[];}
WebInspector.DevicesView.DiscoveryView.prototype={_addRuleButtonClicked:function()
{this._list.addNewItem(this._portForwardingConfig.length,{port:"",address:""});},discoveryConfigChanged:function(discoverUsbDevices,portForwardingEnabled,portForwardingConfig)
{this._discoverUsbDevicesCheckbox.checked=discoverUsbDevices;this._portForwardingEnabledCheckbox.checked=portForwardingEnabled;this._portForwardingConfig=[];this._list.clear();for(var key of Object.keys(portForwardingConfig)){var rule=({port:key,address:portForwardingConfig[key]});this._portForwardingConfig.push(rule);this._list.appendItem(rule,true);}},renderItem:function(item,editable)
{var rule=(item);var element=createElementWithClass("div","port-forwarding-list-item");var port=element.createChild("div","port-forwarding-value port-forwarding-port");port.createChild("span","port-localhost").textContent=WebInspector.UIString("localhost:");port.createTextChild(rule.port);element.createChild("div","port-forwarding-separator");element.createChild("div","port-forwarding-value").textContent=rule.address;return element;},removeItemRequested:function(item,index)
{this._portForwardingConfig.splice(index,1);this._list.removeItem(index);this._updateDiscoveryConfig();},commitEdit:function(item,editor,isNew)
{var rule=(item);rule.port=editor.control("port").value.trim();rule.address=editor.control("address").value.trim();if(isNew)
this._portForwardingConfig.push(rule);this._updateDiscoveryConfig();},beginEdit:function(item)
{var rule=(item);var editor=this._createEditor();editor.control("port").value=rule.port;editor.control("address").value=rule.address;return editor;},_createEditor:function()
{if(this._editor)
return this._editor;var editor=new WebInspector.ListWidget.Editor();this._editor=editor;var content=editor.contentElement();var fields=content.createChild("div","port-forwarding-edit-row");fields.createChild("div","port-forwarding-value port-forwarding-port").appendChild(editor.createInput("port","text","Device port (3333)",portValidator.bind(this)));fields.createChild("div","port-forwarding-separator port-forwarding-separator-invisible");fields.createChild("div","port-forwarding-value").appendChild(editor.createInput("address","text","Local address (dev.example.corp:3333)",addressValidator));return editor;function portValidator(item,index,input)
{var value=input.value.trim();var match=value.match(/^(\d+)$/);if(!match)
return false;var port=parseInt(match[1],10);if(port<1024||port>65535)
return false;for(var i=0;i<this._portForwardingConfig.length;++i){if(i!==index&&this._portForwardingConfig[i].port===value)
return false;}
return true;}
function addressValidator(item,index,input)
{var match=input.value.trim().match(/^([a-zA-Z0-9\.\-_]+):(\d+)$/);if(!match)
return false;var port=parseInt(match[2],10);return port<=65535;}},_updateDiscoveryConfig:function()
{var configMap=({});for(var rule of this._portForwardingConfig)
configMap[rule.port]=rule.address;InspectorFrontendHost.setDevicesDiscoveryConfig(this._discoverUsbDevicesCheckbox.checked,this._portForwardingEnabledCheckbox.checked,configMap);},__proto__:WebInspector.VBox.prototype}
WebInspector.DevicesView.DeviceView=function()
{WebInspector.VBox.call(this);this.setMinimumSize(100,100);this.contentElement.classList.add("device-view");var topRow=this.contentElement.createChild("div","hbox device-text-row");this._deviceTitle=topRow.createChild("div","view-title");this._deviceSerial=topRow.createChild("div","device-serial");this._deviceOffline=this.contentElement.createChild("div");this._deviceOffline.textContent=WebInspector.UIString("Pending authentication: please accept debugging session on the device.");this._noBrowsers=this.contentElement.createChild("div");this._noBrowsers.textContent=WebInspector.UIString("No browsers detected.");this._browsers=this.contentElement.createChild("div","device-browser-list vbox");this._browserById=new Map();this._device=null;}
WebInspector.DevicesView.BrowserSection;WebInspector.DevicesView.PageSection;WebInspector.DevicesView.DeviceView.prototype={update:function(device)
{if(!this._device||this._device.adbModel!==device.adbModel)
this._deviceTitle.textContent=device.adbModel;if(!this._device||this._device.adbSerial!==device.adbSerial)
this._deviceSerial.textContent="#"+device.adbSerial;this._deviceOffline.classList.toggle("hidden",device.adbConnected);this._noBrowsers.classList.toggle("hidden",!device.adbConnected||device.browsers.length);this._browsers.classList.toggle("hidden",!device.adbConnected||!device.browsers.length);var browserIds=new Set();for(var browser of device.browsers)
browserIds.add(browser.id);for(var browserId of this._browserById.keys()){if(!browserIds.has(browserId)){this._browserById.get(browserId).element.remove();this._browserById.remove(browserId);}}
for(var browser of device.browsers){var section=this._browserById.get(browser.id);if(!section){section=this._createBrowserSection();this._browserById.set(browser.id,section);this._browsers.appendChild(section.element);}
this._updateBrowserSection(section,browser);}
this._device=device;},_createBrowserSection:function()
{var element=createElementWithClass("div","vbox flex-none");var topRow=element.createChild("div","");var title=topRow.createChild("div","device-browser-title");var newTabRow=element.createChild("div","device-browser-new-tab");newTabRow.createChild("div","").textContent=WebInspector.UIString("New tab:");var newTabInput=newTabRow.createChild("input","");newTabInput.type="text";newTabInput.placeholder=WebInspector.UIString("Enter URL");newTabInput.addEventListener("keydown",newTabKeyDown,false);var newTabButton=createTextButton(WebInspector.UIString("Open"),openNewTab);newTabRow.appendChild(newTabButton);var pages=element.createChild("div","device-page-list vbox");var viewMore=element.createChild("div","device-view-more");viewMore.addEventListener("click",viewMoreClick,false);updateViewMoreTitle();var section={browser:null,element:element,title:title,pages:pages,viewMore:viewMore,newTab:newTabRow,pageSections:new Map()};return section;function viewMoreClick()
{pages.classList.toggle("device-view-more-toggled");updateViewMoreTitle();}
function updateViewMoreTitle()
{viewMore.textContent=pages.classList.contains("device-view-more-toggled")?WebInspector.UIString("View less tabs\u2026"):WebInspector.UIString("View more tabs\u2026");}
function newTabKeyDown(event)
{if(event.keyIdentifier==="Enter"){event.consume(true);openNewTab();}}
function openNewTab()
{if(section.browser){InspectorFrontendHost.openRemotePage(section.browser.id,newTabInput.value.trim()||"about:blank");newTabInput.value="";}}},_updateBrowserSection:function(section,browser)
{if(!section.browser||section.browser.adbBrowserName!==browser.adbBrowserName||section.browser.adbBrowserVersion!==browser.adbBrowserVersion){if(browser.adbBrowserVersion)
section.title.textContent=String.sprintf("%s (%s)",browser.adbBrowserName,browser.adbBrowserVersion);else
section.title.textContent=browser.adbBrowserName;}
var pageIds=new Set();for(var page of browser.pages)
pageIds.add(page.id);for(var pageId of section.pageSections.keys()){if(!pageIds.has(pageId)){section.pageSections.get(pageId).element.remove();section.pageSections.remove(pageId);}}
for(var index=0;index<browser.pages.length;++index){var page=browser.pages[index];var pageSection=section.pageSections.get(page.id);if(!pageSection){pageSection=this._createPageSection();section.pageSections.set(page.id,pageSection);section.pages.appendChild(pageSection.element);}
this._updatePageSection(pageSection,page);if(!index&&section.pages.firstChild!==pageSection.element)
section.pages.insertBefore(pageSection.element,section.pages.firstChild);}
var kViewMoreCount=3;for(var index=0,element=section.pages.firstChild;element;element=element.nextSibling,++index)
element.classList.toggle("device-view-more-page",index>=kViewMoreCount);section.viewMore.classList.toggle("device-needs-view-more",browser.pages.length>kViewMoreCount);section.newTab.classList.toggle("hidden",!browser.adbBrowserChromeVersion);section.browser=browser;},_createPageSection:function()
{var element=createElementWithClass("div","vbox");var titleRow=element.createChild("div","device-page-title-row");var title=titleRow.createChild("div","device-page-title");var inspect=createTextButton(WebInspector.UIString("Inspect"),doAction.bind(null,"inspect"),"device-inspect-button");titleRow.appendChild(inspect);var toolbar=new WebInspector.Toolbar();toolbar.appendToolbarItem(new WebInspector.ToolbarMenuButton("","menu-toolbar-item",appendActions));titleRow.appendChild(toolbar.element);var url=element.createChild("div","device-page-url");var section={page:null,element:element,title:title,url:url,inspect:inspect};return section;function appendActions(contextMenu)
{contextMenu.appendItem(WebInspector.UIString("Reload"),doAction.bind(null,"reload"));contextMenu.appendItem(WebInspector.UIString("Focus"),doAction.bind(null,"activate"));contextMenu.appendItem(WebInspector.UIString("Close"),doAction.bind(null,"close"));}
function doAction(action)
{if(section.page)
InspectorFrontendHost.performActionOnRemotePage(section.page.id,action);}},_updatePageSection:function(section,page)
{if(!section.page||section.page.name!==page.name){section.title.textContent=page.name;section.title.title=page.name;}
if(!section.page||section.page.url!==page.url){section.url.textContent="";section.url.appendChild(WebInspector.linkifyURLAsNode(page.url,undefined,undefined,true));}
section.inspect.disabled=page.adbAttachedForeign;section.page=page;},__proto__:WebInspector.VBox.prototype};WebInspector.DevicesDialog=function()
{}
WebInspector.DevicesDialog.ActionDelegate=function()
{this._view=null;}
WebInspector.DevicesDialog.ActionDelegate.prototype={handleAction:function(context,actionId)
{if(actionId==="devices.dialog.show"){if(!this._view)
this._view=new WebInspector.DevicesView();var dialog=new WebInspector.Dialog();dialog.addCloseButton();this._view.show(dialog.element);dialog.setMaxSize(new Size(700,500));dialog.show();return true;}
return false;}};Runtime.cachedResources["devices/devicesView.css"]="/*\n * Copyright (c) 2015 The Chromium Authors. All rights reserved.\n * Use of this source code is governed by a BSD-style license that can be\n * found in the LICENSE file.\n */\n\n.devices-view {\n    padding-top: 15px;\n}\n\n.devices-sidebar {\n    flex: 0 0 150px;\n    display: flex;\n    flex-direction: column;\n    align-items: stretch;\n}\n\n.devices-sidebar-list {\n    flex: none;\n    display: flex;\n    flex-direction: column;\n    align-items: stretch;\n}\n\n.devices-sidebar-item {\n    color: #222 !important;\n    padding: 6px 6px 6px 16px;\n    flex: auto;\n    display: flex;\n    flex-direction: column;\n    justify-content: center;\n    font-size: 14px;\n}\n\n.devices-sidebar-item.selected {\n    border-left: 6px solid #666 !important;\n    padding-left: 10px;\n}\n\n.devices-sidebar-item-status {\n    font-size: 11px;\n}\n\n.devices-sidebar-item-status:before {\n    content: \"\\25cf\";\n    font-size: 16px;\n    color: red;\n    position: relative;\n    top: 1px;\n    margin-right: 2px;\n}\n\n.devices-sidebar-item.device-connected .devices-sidebar-item-status:before {\n    color: green;\n}\n\n.devices-sidebar-spacer {\n    flex: none;\n}\n\n.devices-view-title {\n    font-size: 16px;\n    margin: 0 0 15px 15px;\n    padding-top: 1px;\n}\n\n.view-title {\n    font-size: 16px;\n}\n\n.devices-footer {\n    border-top: 1px solid #cdcdcd;\n    background-color: #f3f3f3;\n    flex: none;\n    padding: 3px 10px;\n}\n\n.devices-footer > span {\n    white-space: pre;\n}\n\n.usb-checkbox {\n    padding-bottom: 8px;\n}\n\n.port-forwarding-header {\n    display: flex;\n    align-items: center;\n    flex-direction: row;\n    margin-top: 5px;\n}\n\n.add-rule-button {\n    margin: 10px 25px;\n    align-self: flex-start;\n}\n\n.discovery-help {\n    margin: 5px 0 25px 25px;\n}\n\n.discovery-help > span {\n    white-space: pre;\n}\n\n.port-forwarding-list {\n    margin: 10px 0 0 25px;\n    max-width: 500px;\n    flex: 0 1 auto;\n}\n\n.port-forwarding-list-empty {\n    flex: auto;\n    height: 30px;\n    display: flex;\n    align-items: center;\n    justify-content: center;\n}\n\n.port-forwarding-list-item {\n    padding: 3px 5px 3px 5px;\n    height: 30px;\n    display: flex;\n    align-items: center;\n    position: relative;\n    flex: auto 1 1;\n}\n\n.port-forwarding-value {\n    white-space: nowrap;\n    text-overflow: ellipsis;\n    -webkit-user-select: none;\n    color: #222;\n    flex: 3 1 0;\n    overflow: hidden;\n}\n\n.port-forwarding-value.port-forwarding-port {\n    flex: 1 1 0;\n}\n\n.port-localhost {\n    color: #aaa;\n}\n\n.port-forwarding-separator {\n    flex: 0 0 1px;\n    background-color: rgb(231, 231, 231);\n    height: 30px;\n    margin: 0 4px;\n}\n\n.port-forwarding-separator-invisible {\n    visibility: hidden;\n    height: 100% !important;\n}\n\n.port-forwarding-edit-row {\n    flex: none;\n    display: flex;\n    flex-direction: row;\n    margin: 6px 5px;\n    align-items: center;\n}\n\n.port-forwarding-edit-row input {\n    width: 100%;\n    text-align: inherit;\n}\n\n.port-forwarding-footer {\n    overflow: hidden;\n    margin: 15px 0 0 25px;\n    max-width: 500px;\n}\n\n.port-forwarding-footer > * {\n    white-space: pre-wrap;\n}\n\n.device-view {\n    overflow: auto;\n    -webkit-user-select: text;\n    flex: auto;\n}\n\n.device-text-row {\n    align-items: baseline;\n    margin-bottom: 20px;\n}\n\n.device-serial {\n    color: #777;\n    margin-left: 5px;\n}\n\n.device-browser-list {\n    flex: auto;\n    overflow: auto;\n    padding-right: 10px;\n}\n\n.device-browser-list > div {\n    margin-bottom: 15px;\n}\n\n.device-browser-title {\n    font-size: 16px;\n}\n\n.device-browser-new-tab {\n    display: flex;\n    flex-direction: row;\n    align-items: center;\n    margin: 10px 0 0 10px;\n}\n\n.device-browser-new-tab > div {\n    font-size: 13px;\n}\n\n.device-browser-new-tab > input {\n    margin: 0 10px;\n}\n\n.device-page-list {\n    margin: 10px 0 0 10px;\n    overflow-x: auto;\n    align-items: stretch;\n    flex: none;\n}\n\n.device-page-list > div {\n    flex: none;\n    padding: 5px 0;\n}\n\n.device-page-list:not(.device-view-more-toggled) > div.device-view-more-page {\n    display: none;\n}\n\n.device-page-title-row {\n    display: flex;\n    flex-direction: row;\n    align-items: center;\n}\n\n.device-page-title {\n    font-size: 15px;\n    flex: auto;\n    white-space: nowrap;\n    text-overflow: ellipsis;\n    overflow: hidden;\n}\n\n.device-page-title-row .toolbar {\n    margin-left: 3px;\n    padding: 0;\n    border-radius: 3px;\n}\n\n.device-page-title-row .toolbar:hover {\n    background-color: hsl(0, 0%, 90%);\n}\n\n.device-page-url {\n    margin: 3px 0;\n}\n\n.device-page-url a {\n    color: #777;\n    word-break: break-all;\n}\n\n.device-view-more {\n    cursor: pointer;\n    text-decoration: underline;\n    color: rgb(17, 85, 204);\n    margin: 5px 0 0 10px;\n    display: none;\n}\n\n.device-view-more.device-needs-view-more  {\n    display: block;\n}\n/*# sourceURL=devices/devicesView.css */";