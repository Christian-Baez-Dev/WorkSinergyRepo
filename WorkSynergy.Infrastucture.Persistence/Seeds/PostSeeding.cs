using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Seeds
{
    public static class PostSeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.Posts.Count() == 0)
            {

                var posts = new List<Post>
                {
                    new Post
                    {
                        Title = "Diseño de interfaz para aplicación móvil",
                        Description = "Requerimos un diseñador especializado en UX/UI para mejorar la experiencia del usuario.",
                        CurrencyId = 1,
                        CreatorUserId = "client1-id",
                        From = 300.00,
                        To = 700.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 1, TagId = 5 }, // Design
                            new PostTag { PostId = 1, TagId = 7 }  // Frontend Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 1, AbilityId = 1 }, // UX/UI
                            new PostAbility { PostId = 1, AbilityId = 3 }, // Web Design
                            new PostAbility { PostId = 1, AbilityId = 4 }  // TypeScript
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de backend con NodeJs",
                        Description = "Busco un programador para construir un API escalable.",
                        CurrencyId = 2,
                        CreatorUserId = "client1-id",
                        From = 1000.00,
                        To = 2500.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 2, TagId = 2 } // Backend Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 2, AbilityId = 15 }, // NodeJs
                            new PostAbility { PostId = 2, AbilityId = 9 },  // Database Management
                            new PostAbility { PostId = 2, AbilityId = 19 }  // PostgreSQL
                        }
                    },
                    new Post
                    {
                        Title = "Creación de modelo de IA para predicción",
                        Description = "Se busca especialista en IA para construir un modelo de predicción de ventas.",
                        CurrencyId = 1,
                        CreatorUserId = "client2-id",
                        From = 2000.00,
                        To = 5000.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 3, TagId = 8 }, // IA
                            new PostTag { PostId = 3, TagId = 9 }  // Data Science
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 3, AbilityId = 8 },  // Machine Learning
                            new PostAbility { PostId = 3, AbilityId = 12 }, // AWS
                            new PostAbility { PostId = 3, AbilityId = 18 }  // MongoDB
                        }
                    },
                    new Post
                    {
                        Title = "Optimización de base de datos SQL Server",
                        Description = "Busco experto en optimización de bases de datos para mejorar el rendimiento de consultas SQL Server.",
                        CurrencyId = 2,
                        CreatorUserId = "client2-id",
                        From = 500.00,
                        To = 1500.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 4, TagId = 3 }, // Database Engineering
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 4, AbilityId = 17 }, // SQL Server
                            new PostAbility { PostId = 4, AbilityId = 9 },  // Database Management
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de aplicación web con Angular",
                        Description = "Necesitamos un desarrollador frontend para crear una SPA con Angular.",
                        CurrencyId = 1,
                        CreatorUserId = "client3-id",
                        From = 800.00,
                        To = 2000.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 5, TagId = 7 }, // Frontend Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 5, AbilityId = 5 }, // Angular
                            new PostAbility { PostId = 5, AbilityId = 4 }, // TypeScript
                            new PostAbility { PostId = 5, AbilityId = 6 }  // React
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de microservicio en ASP.NET Core",
                        Description = "Requerimos un desarrollador backend con experiencia en ASP.NET Core y arquitectura de microservicios.",
                        CurrencyId = 2,
                        CreatorUserId = "client3-id",
                        From = 1500.00,
                        To = 3000.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 6, TagId = 2 }, // Backend Development
                            new PostTag { PostId = 6, TagId = 3 }  // Database Engineering
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 6, AbilityId = 7 },  // ASP.NET Core
                            new PostAbility { PostId = 6, AbilityId = 10 }, // Java
                            new PostAbility { PostId = 6, AbilityId = 9 }   // Database Management
                        }
                    },
                    new Post
                    {
                        Title = "Diseño 3D para modelado arquitectónico",
                        Description = "Se busca diseñador con experiencia en modelado 3D para proyecto arquitectónico.",
                        CurrencyId = 1,
                        CreatorUserId = "client4-id",
                        From = 1200.00,
                        To = 4000.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 7, TagId = 5 } // Design
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 7, AbilityId = 11 }, // 3D Design
                            new PostAbility { PostId = 7, AbilityId = 16 }, // Spring
                            new PostAbility { PostId = 7, AbilityId = 18 }  // MongoDB
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de aplicación web con VueJs",
                        Description = "Se necesita un desarrollador frontend para trabajar en un proyecto con VueJs.",
                        CurrencyId = 2,
                        CreatorUserId = "client4-id",
                        From = 800.00,
                        To = 1800.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 8, TagId = 7 }, // Frontend Development
                            new PostTag { PostId = 8, TagId = 10 } // Full Stack Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 8, AbilityId = 14 }, // VueJs
                            new PostAbility { PostId = 8, AbilityId = 13 }, // Firebase
                        }
                    },
                    new Post
                    {
                        Title = "Implementación de sistema de aprendizaje automático",
                        Description = "Buscamos experto en Machine Learning para desarrollar un modelo predictivo.",
                        CurrencyId = 1,
                        CreatorUserId = "client1-id",
                        From = 2500.00,
                        To = 6000.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 9, TagId = 8 }, // IA
                            new PostTag { PostId = 9, TagId = 9 }  // Data Science
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 9, AbilityId = 8 },  // Machine Learning
                            new PostAbility { PostId = 9, AbilityId = 12 }, // AWS
                            new PostAbility { PostId = 9, AbilityId = 20 }  // SQLite
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de backend con Spring Boot",
                        Description = "Requerimos un desarrollador backend con experiencia en Spring Boot para trabajar en un sistema escalable.",
                        CurrencyId = 2,
                        CreatorUserId = "client1-id",
                        From = 1000.00,
                        To = 3000.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 10, TagId = 2 }, // Backend Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 10, AbilityId = 16 }, // Spring
                            new PostAbility { PostId = 10, AbilityId = 18 }, // MongoDB
                            new PostAbility { PostId = 10, AbilityId = 17 }  // SQL Server
                        }
                    },
                    new Post
                    {
                        Title = "Automatización de procesos con Python",
                        Description = "Buscamos un desarrollador que automatice tareas repetitivas en nuestra plataforma.",
                        CurrencyId = 1,
                        CreatorUserId = "client2-id",
                        From = 500.00,
                        To = 1500.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 11, TagId = 8 }  // IA
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 11, AbilityId = 8 },  // Machine Learning
                            new PostAbility { PostId = 11, AbilityId = 18 }  // MongoDB
                        }
                    },
                    new Post
                    {
                        Title = "Integración de Firebase en aplicación móvil",
                        Description = "Necesitamos un desarrollador que implemente funcionalidades de Firebase.",
                        CurrencyId = 2,
                        CreatorUserId = "client2-id",
                        From = 600.00,
                        To = 1200.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 12, TagId = 7 }, // Frontend Development
                            new PostTag { PostId = 12, TagId = 10 } // Full Stack Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 12, AbilityId = 13 }, // Firebase
                            new PostAbility { PostId = 12, AbilityId = 6 },  // React
                        }
                    },
                    new Post
                    {
                        Title = "Optimización de sistema basado en AWS",
                        Description = "Se busca un ingeniero de sistemas para optimizar un entorno basado en AWS.",
                        CurrencyId = 1,
                        CreatorUserId = "client3-id",
                        From = 2500.00,
                        To = 5000.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 13, TagId = 4 } // Cloud Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 13, AbilityId = 12 }, // AWS
                            new PostAbility { PostId = 13, AbilityId = 16 }, // Spring
                            new PostAbility { PostId = 13, AbilityId = 9 }   // Database Management
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de sistema de reportes con SQL Server",
                        Description = "Buscamos un desarrollador que construya reportes complejos usando SQL Server.",
                        CurrencyId = 2,
                        CreatorUserId = "client3-id",
                        From = 1200.00,
                        To = 3000.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 14, TagId = 3 } // Database Engineering
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 14, AbilityId = 17 }, // SQL Server
                            new PostAbility { PostId = 14, AbilityId = 20 }  // SQLite
                        }
                    },
                    new Post
                    {
                        Title = "Desarrollo de aplicación full-stack",
                        Description = "Requerimos un equipo para construir una aplicación completa con tecnologías modernas.",
                        CurrencyId = 1,
                        CreatorUserId = "client4-id",
                        From = 5000.00,
                        To = 10000.00,
                        ContractOptionId = 1, // Fixed Price
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 15, TagId = 10 } // Full Stack Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 15, AbilityId = 15 }, // NodeJs
                            new PostAbility { PostId = 15, AbilityId = 14 }, // VueJs
                            new PostAbility { PostId = 15, AbilityId = 6 }   // React
                        }
                    },
                    new Post
                    {
                        Title = "Creación de panel administrativo en Angular",
                        Description = "Necesitamos un panel administrativo para gestionar recursos internos.",
                        CurrencyId = 2,
                        CreatorUserId = "client4-id",
                        From = 1500.00,
                        To = 3000.00,
                        ContractOptionId = 2, // Per Hour
                        Tags = new List<PostTag>
                        {
                            new PostTag { PostId = 16, TagId = 7 } // Frontend Development
                        },
                        Abilities = new List<PostAbility>
                        {
                            new PostAbility { PostId = 16, AbilityId = 5 }, // Angular
                            new PostAbility { PostId = 16, AbilityId = 4 }, // TypeScript
                        }
                    }
                };

                context.Posts.AddRange(posts);
                await context.SaveChangesAsync();
            }
        }

    }
}
