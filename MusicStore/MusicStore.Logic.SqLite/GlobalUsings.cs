///   L O G I C   ///
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
global using SQLitePCL;

/// EntityFramework 
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Sqlite;

/// MusikStore 
global using MusicStore.Logic.SqLite;
global using MusicStore.Logic.SqLite.Entities;
global using MusicStore.Logic.SqLite.Contracts;
global using MusicStore.Logic.SqLite.Statistics;
global using MusicStore.Logic.SqLite.Extensions;
global using MusicStore.Logic.SqLite.DataContext;


///   N A M E S P A C E   ///
namespace MusicStore.Logic.SqLite;