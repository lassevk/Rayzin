using System.Diagnostics.CodeAnalysis;

namespace Rayzin;

[ExcludeFromCodeCoverage]
public readonly record struct RIntersection(double T, RObject Object);