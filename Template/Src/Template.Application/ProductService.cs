using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Uow;
using Template.Domain.Entities;
using Template.Domain.Repositories;
using Template.Infrastructure.Dtos;

namespace Template.Application
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return (await _productRepository.FindAllAsync(p => true))
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                })
                .ToList();
        }

        public async Task CreateProduct(CreateProductDto productDto)
        {
            var product = new Product(productDto.Name, productDto.Description, productDto.Price);
            _productRepository.Add(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateProduct(Guid productId, UpdateProductDto productDto)
        {
            var product = await _productRepository.FindAsync(productId);
            if (product != null)
            {
                product.Update(productDto.Name, productDto.Description, productDto.Price);
                _productRepository.Update(product);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteProduct(Guid productId)
        {
            var product = await _productRepository.FindAsync(productId);
            if (product != null)
            {
                _productRepository.Remove(product);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
