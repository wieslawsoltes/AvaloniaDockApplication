﻿using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Data;
using AvaloniaDockApplication.Models.Documents;
using AvaloniaDockApplication.Models.Tools;
using AvaloniaDockApplication.ViewModels;
using AvaloniaDockApplication.ViewModels.Documents;
using AvaloniaDockApplication.ViewModels.Tools;
using Dock.Avalonia.Controls;
using Dock.Model.Controls;
using Dock.Model.Core;
using Dock.Model.ReactiveUI;
using Dock.Model.ReactiveUI.Controls;
using ReactiveUI;

namespace AvaloniaDockApplication
{
    public class MainDockFactory : Factory
    {
        private IDocumentDock _documentDock;
        private readonly object _context;

        public MainDockFactory(object context)
        {
            _context = context;
        }
 
        public override IRootDock CreateLayout()
        {
            var document1 = new TestDocumentViewModel
            {
                Id = "Document1",
                Title = "Document1"
            };

            var document2 = new TestDocumentViewModel
            {
                Id = "Document2",
                Title = "Document2"
            };

            var leftTopTool1 = new LeftTopTool1ViewModel
            {
                Id = "LeftTop1",
                Title = "LeftTop1"
            };

            var leftTopTool2 = new LeftTopTool2ViewModel
            {
                Id = "LeftTop2",
                Title = "LeftTop2"
            };

            var leftBottomTool1 = new LeftBottomTool1ViewModel
            {
                Id = "LeftBottom1",
                Title = "LeftBottom1"
            };

            var leftBottomTool2 = new LeftBottomTool2ViewModel
            {
                Id = "LeftBottom2",
                Title = "LeftBottom2"
            };

            var rightTopTool1 = new RightTopTool1ViewModel
            {
                Id = "RightTop1",
                Title = "RightTop1"
            };

            var rightTopTool2 = new RightTopTool2ViewModel
            {
                Id = "RightTop2",
                Title = "RightTop2"
            };

            var rightBottomTool1 = new RightBottomTool1ViewModel
            {
                Id = "RightBottom1",
                Title = "RightBottom1"
            };

            var rightBottomTool2 = new RightBottomTool2ViewModel
            {
                Id = "RightBottom2",
                Title = "RightBottom2"
            };

            var documentDock = new DocumentDock
            {
                Id = "DocumentsPane",
                Title = "DocumentsPane",
                Proportion = double.NaN,
                ActiveDockable = document1,
                VisibleDockables = CreateList<IDockable>
                (
                    document1,
                    document2
                )
            };

            documentDock.CanCreateDocument = true;
            documentDock.CreateDocument = ReactiveCommand.Create(() =>
            {
                var index = documentDock.VisibleDockables?.Count + 1;
                var document = new TestDocumentViewModel {Id = $"Document{index}", Title = $"Document{index}"};
                this.AddDockable(documentDock, document);
                this.SetActiveDockable(document);
                this.SetFocusedDockable(documentDock, document);
            });

            var mainLayout = new ProportionalDock
            {
                Id = "MainLayout",
                Title = "MainLayout",
                Proportion = double.NaN,
                Orientation = Orientation.Horizontal,
                ActiveDockable = null,
                VisibleDockables = CreateList<IDockable>
                (
                    new ProportionalDock
                    {
                        Id = "LeftPane",
                        Title = "LeftPane",
                        Proportion = double.NaN,
                        Orientation = Orientation.Vertical,
                        ActiveDockable = null,
                        VisibleDockables = CreateList<IDockable>
                        (
                            new ToolDock
                            {
                                Id = "LeftPaneTop",
                                Title = "LeftPaneTop",
                                Proportion = double.NaN,
                                ActiveDockable = leftTopTool1,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    leftTopTool1,
                                    leftTopTool2
                                ),
                                Alignment = Alignment.Left,
                                GripMode = GripMode.Visible
                            },
                            new ProportionalDockSplitter()
                            {
                                Id = "LeftPaneTopSplitter",
                                Title = "LeftPaneTopSplitter"
                            },
                            new ToolDock
                            {
                                Id = "LeftPaneBottom",
                                Title = "LeftPaneBottom",
                                Proportion = double.NaN,
                                ActiveDockable = leftBottomTool1,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    leftBottomTool1,
                                    leftBottomTool2
                                ),
                                Alignment = Alignment.Left,
                                GripMode = GripMode.Visible
                            }
                        )
                    },
                    new ProportionalDockSplitter()
                    {
                        Id = "LeftSplitter",
                        Title = "LeftSplitter"
                    },
                    documentDock,
                    new ProportionalDockSplitter()
                    {
                        Id = "RightSplitter",
                        Title = "RightSplitter"
                    },
                    new ProportionalDock
                    {
                        Id = "RightPane",
                        Title = "RightPane",
                        Proportion = double.NaN,
                        Orientation = Orientation.Vertical,
                        ActiveDockable = null,
                        VisibleDockables = CreateList<IDockable>
                        (
                            new ToolDock
                            {
                                Id = "RightPaneTop",
                                Title = "RightPaneTop",
                                Proportion = double.NaN,
                                ActiveDockable = rightTopTool1,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    rightTopTool1,
                                    rightTopTool2
                                ),
                                Alignment = Alignment.Right,
                                GripMode = GripMode.Visible
                            },
                            new ProportionalDockSplitter()
                            {
                                Id = "RightPaneTopSplitter",
                                Title = "RightPaneTopSplitter"
                            },
                            new ToolDock
                            {
                                Id = "RightPaneBottom",
                                Title = "RightPaneBottom",
                                Proportion = double.NaN,
                                ActiveDockable = rightBottomTool1,
                                VisibleDockables = CreateList<IDockable>
                                (
                                    rightBottomTool1,
                                    rightBottomTool2
                                ),
                                Alignment = Alignment.Right,
                                GripMode = GripMode.Visible
                            }
                        )
                    }
                )
            };

            var mainView = new MainViewModel
            {
                Id = "Main",
                Title = "Main",
                ActiveDockable = mainLayout,
                VisibleDockables = CreateList<IDockable>(mainLayout)
            };

            var root = CreateRootDock();

            root.Id = "Root";
            root.Title = "Root";
            root.ActiveDockable = mainView;
            root.DefaultDockable = mainView;
            root.VisibleDockables = CreateList<IDockable>(mainView);

            _documentDock = documentDock;

            return root;
        }

        public override void InitLayout(IDockable layout)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                [nameof(IRootDock)] = () => _context,
                [nameof(IProportionalDock)] = () => _context,
                [nameof(IDocumentDock)] = () => _context,
                [nameof(IToolDock)] = () => _context,
                [nameof(IProportionalDockSplitter)] = () => _context,
                [nameof(IDockWindow)] = () => _context,
                [nameof(IDocument)] = () => _context,
                [nameof(ITool)] = () => _context,
                ["Document1"] = () => new TestDocument(),
                ["Document2"] = () => new TestDocument(),
                ["LeftTop1"] = () => new LeftTopTool1(),
                ["LeftTop2"] = () => new LeftTopTool2(),
                ["LeftBottom1"] = () => new LeftBottomTool1(),
                ["LeftBottom2"] = () => new LeftBottomTool2(),
                ["RightTop1"] = () => new RightTopTool1(),
                ["RightTop2"] = () => new RightTopTool2(),
                ["RightBottom1"] = () => new RightBottomTool1(),
                ["RightBottom2"] = () => new RightBottomTool2(),
                ["LeftPane"] = () => _context,
                ["LeftPaneTop"] = () => _context,
                ["LeftPaneTopSplitter"] = () => _context,
                ["LeftPaneBottom"] = () => _context,
                ["RightPane"] = () => _context,
                ["RightPaneTop"] = () => _context,
                ["RightPaneTopSplitter"] = () => _context,
                ["RightPaneBottom"] = () => _context,
                ["DocumentsPane"] = () => _context,
                ["MainLayout"] = () => _context,
                ["LeftSplitter"] = () => _context,
                ["RightSplitter"] = () => _context,
                ["MainLayout"] = () => _context,
                ["Main"] = () => _context,
            };

            this.HostWindowLocator = new Dictionary<string, Func<IHostWindow>>
            {
                [nameof(IDockWindow)] = () =>
                {
                    var hostWindow = new HostWindow()
                    {
                        [!HostWindow.TitleProperty] = new Binding("ActiveDockable.Title")
                    };
                    return hostWindow;
                }
            };

            this.DockableLocator = new Dictionary<string, Func<IDockable>>
            {
            };

            base.InitLayout(layout);

            this.SetActiveDockable(_documentDock);
            this.SetFocusedDockable(_documentDock, _documentDock.VisibleDockables?.FirstOrDefault());
        }
    }
}
