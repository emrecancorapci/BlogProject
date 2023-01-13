export interface AddCommentRequest {
  content: string
  authorId: number
  postId: number
  parentId?: number
}
