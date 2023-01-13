export interface PostRequest {
  title: string
  content: string
  authorId: number
  thumbnailUrl: string
  addCommentsEnabled: boolean
  addReactionsEnabled: boolean
  categoryId: number
}
