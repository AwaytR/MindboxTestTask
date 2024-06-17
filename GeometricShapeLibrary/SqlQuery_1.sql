/* Вывод названий всех продуктов и всех категорий, которым они принадлежат */
SELECT 
	product.[Name],
	category.[Name]
FROM
	[dbo].[ProductCategory] as productCategory
	RIGHT JOIN
		[dbo].[Product] as product
		ON
			productCategory.[ProductId] = product.[Id]
	LEFT JOIN
		[dbo].[Category] as category
		ON
			productCategory.[CategoryId] = category.[Id]