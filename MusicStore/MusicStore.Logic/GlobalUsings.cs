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

/// EntityFramework 
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Sqlite;

/// MusikStore 
global using MusicStore.Logic;
global using MusicStore.Logic.Models;
global using MusicStore.Logic.Entities;
global using MusicStore.Logic.Contracts;
global using MusicStore.Logic.Statistics;
global using MusicStore.Logic.Extensions;
global using MusicStore.Logic.DataContext;


///   N A M E S P A C E   ///
namespace MusicStore.Logic;