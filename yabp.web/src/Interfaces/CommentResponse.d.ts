export interface CommentResponse {
  content: string
  authorId: number
  postId: number
  parentId?: number
  created: string
}
