using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null)
            {
                throw new BadRequestException("Product info is not valid.");
            }

            Product product = new()
            {
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                MakeFlag = productDto.MakeFlag,
                FinishedGoodsFlag = productDto.FinishedGoodsFlag,
                Color = productDto.Color,
                SafetyStockLevel = productDto.SafetyStockLevel,
                ReorderPoint = productDto.ReorderPoint,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                Size = productDto.Size,
                SizeUnitMeasureCode = productDto.SizeUnitMeasureCode,
                WeightUnitMeasureCode = productDto.WeightUnitMeasureCode,
                Weight = productDto.Weight,
                DaysToManufacture = productDto.DaysToManufacture,
                ProductLine = productDto.ProductLine,
                Class = productDto.Class,
                Style = productDto.Style,
                ProductSubcategoryId = productDto.ProductSubcategoryId,
                ProductModelId = productDto.ProductModelId
            };

            return await _productRepository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _productRepository.DeleteProduct(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAllProducts();
            List<GetProductDto> productsDto = [];

            foreach (var product in products)
            {
                GetProductDto dto = new()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    MakeFlag = product.MakeFlag,
                    FinishedGoodsFlag = product.FinishedGoodsFlag,
                    Color = product.Color,
                    SafetyStockLevel = product.SafetyStockLevel,
                    ReorderPoint = product.ReorderPoint,
                    StandardCost = product.StandardCost,
                    ListPrice = product.ListPrice,
                    Size = product.Size,
                    SizeUnitMeasureCode = product.SizeUnitMeasureCode,
                    WeightUnitMeasureCode = product.WeightUnitMeasureCode,
                    Weight = product.Weight,
                    DaysToManufacture = product.DaysToManufacture,
                    ProductLine = product.ProductLine,
                    Class = product.Class,
                    Style = product.Style,
                    ProductSubcategoryId = product.ProductSubcategoryId,
                    ProductModelId = product.ProductModelId
                };

                productsDto.Add(dto);
            }

            return productsDto;
        }

        public async Task<GetProductDto?> GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductId is not valid");
            }

            var product = await ValidateProductExistence(id);

            GetProductDto dto = new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                MakeFlag = product.MakeFlag,
                FinishedGoodsFlag = product.FinishedGoodsFlag,
                Color = product.Color,
                SafetyStockLevel = product.SafetyStockLevel,
                ReorderPoint = product.ReorderPoint,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                Size = product.Size,
                SizeUnitMeasureCode = product.SizeUnitMeasureCode,
                WeightUnitMeasureCode = product.WeightUnitMeasureCode,
                Weight = product.Weight,
                DaysToManufacture = product.DaysToManufacture,
                ProductLine = product.ProductLine,
                Class = product.Class,
                Style = product.Style,
                ProductSubcategoryId = product.ProductSubcategoryId,
                ProductModelId = product.ProductModelId
            };
            return dto;

        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            if(productDto is null)
            {
                throw new BadRequestException("ProductCategory info is not valid.");
            }

            var product = await ValidateProductExistence(productDto.ProductId);
            
            product.Name = string.IsNullOrWhiteSpace(productDto.Name) ? product.Name : productDto.Name;
            product.ProductNumber = string.IsNullOrWhiteSpace(productDto.ProductNumber) ? product.ProductNumber : productDto.ProductNumber;
            product.MakeFlag = productDto.MakeFlag.Equals(null) ? product.MakeFlag : productDto.MakeFlag;
            product.FinishedGoodsFlag = productDto.FinishedGoodsFlag.Equals("") ? product.FinishedGoodsFlag : productDto.FinishedGoodsFlag;
            product.Color = string.IsNullOrWhiteSpace(productDto.Color) ? product.Color : productDto.Color;
            product.SafetyStockLevel = productDto.SafetyStockLevel.Equals("") ? product.SafetyStockLevel : productDto.SafetyStockLevel;
            product.ReorderPoint = productDto.ReorderPoint.Equals("") ? product.ReorderPoint : productDto.ReorderPoint;
            product.StandardCost = productDto.StandardCost.Equals("") ? product.StandardCost : productDto.StandardCost;
            product.ListPrice = productDto.ListPrice.Equals("") ? product.ListPrice : productDto.ListPrice;
            product.Size = string.IsNullOrWhiteSpace(productDto.Size) ? product.Size : productDto.Size;
            product.SizeUnitMeasureCode = string.IsNullOrWhiteSpace(productDto.SizeUnitMeasureCode) ? product.SizeUnitMeasureCode : productDto.SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = string.IsNullOrWhiteSpace(productDto.WeightUnitMeasureCode) ? product.WeightUnitMeasureCode : productDto.WeightUnitMeasureCode;
            product.Weight = productDto.Weight.Equals("") ? product.Weight : productDto.Weight;
            product.DaysToManufacture = productDto.DaysToManufacture.Equals("") ? product.DaysToManufacture : productDto.DaysToManufacture;
            product.ProductLine = string.IsNullOrWhiteSpace(productDto.ProductLine) ? product.ProductLine : productDto.ProductLine;
            product.Class = string.IsNullOrWhiteSpace(productDto.Class) ? product.Class : productDto.Class;
            product.Style = string.IsNullOrWhiteSpace(productDto.Style) ? product.Style : productDto.Style;
            product.ProductSubcategoryId = productDto.ProductSubcategoryId.Equals("") ? product.ProductSubcategoryId : productDto.ProductSubcategoryId;
            product.ProductModelId = productDto.ProductModelId.Equals("") ? product.ProductModelId : productDto.ProductModelId;

            return await _productRepository.UpdateProduct(product);
        }

        private async Task<Product> ValidateProductExistence(int id)
        {
            var existingProduct = await _productRepository.GetProductById(id)
                            ?? throw new NotFoundException($"Product with Id: {id} was not found.");

            return existingProduct;
        }
    }
}