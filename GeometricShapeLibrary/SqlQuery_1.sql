/* Вывод названий всех продуктов и всех категорий, которым они принадлежат */
SELECT 
	product.[Name],
	category.[Name]
FROM
	[dbo].[Product] as product
	LEFT JOIN
		[dbo].[Category] as category
		ON
			product.[Category] = category.[Id]