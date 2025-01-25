///   C O N A P P   ///
/// System 
global using System;
global using System.Linq;
global using System.Text;
global using System.Drawing;
global using System.Diagnostics;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.Runtime.CompilerServices;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

global using System.Linq.Dynamic.Core;

/// EntityFramework
global using Microsoft.EntityFrameworkCore;

/// MusicStore 
global using MusicStore.Logic.DataContext;
global using MusicStore.Logic.Extensions;
global using MusicStore.Logic.Statistics;
/// MusikStore 
global using MusicStore.Logic.SqLite;
global using MusicStore.Logic.SqLite.Entities;
global using MusicStore.Logic.SqLite.Contracts;
// global using MusicStore.Logic.SqLite.Statistics;
// global using MusicStore.Logic.SqLite.Extensions;
global using MusicStore.Logic.SqLite.DataContext;

global using MusicStoreContext = MusicStore.Logic.DataContext.MusicStoreContext;
global using IContext = MusicStore.Logic.SqLite.Contracts.IContext;
global using Entities = MusicStore.Logic.SqLite.Entities;
global using Factory = MusicStore.Logic.SqLite.DataContext.Factory;


///   N A M E S P A C E   ///
namespace MusicStore.ConApp;